using FcmSharp.MessageEntities.Request;
using FcmSharp.MessageEntities.Response;
using Jil;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FcmSharp
{
  public class FcmAPIClient
  {
    string apiKey;
    string baseUri;

    public FcmAPIClient(string apiKey, string baseUri = "https://fcm.googleapis.com/fcm/send")
    {
      this.apiKey = apiKey;
      this.baseUri = baseUri;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="to" <see cref="Message.To"/>
    /// <param name="data"></param>
    public async Task<MessageResponse> SendAsync<TResult>(MessageOptions options, string to, object data, NotificationPayload notification = null) where TResult : MessageResponse
    {
      string response = await SendAsync(options, to, data, notification);

      return JSON.Deserialize<MessageResponse>(response, Options.CamelCase);
    }

    public async Task<MessageResponse> SendAsync<TResult>(MessageOptions options, List<string> registrationdIds, object data, NotificationPayload notification = null) where TResult : MessageResponse
    {
      string response = await SendAsync(options, registrationdIds, data, notification);

      return JSON.Deserialize<MessageResponse>(response, Options.CamelCase);
    }

    public async Task<string> SendAsync(MessageOptions options, string to, object data, NotificationPayload notification = null)
    {
      DataMessage dataMessage = new DataMessage(options, to, data, notification);

      return await PostAsync(dataMessage);
    }

    public async Task<string> SendAsync(MessageOptions options, List<string> registrationdIds, object data, NotificationPayload notification = null)
    {
      DataMessage dataMessage = new DataMessage(options, registrationdIds, data, notification);

      return await PostAsync(dataMessage);
    }

    private async Task<string> PostAsync(DataMessage requestMessage)
    {
      WebRequest wRequest = WebRequest.Create(baseUri);

      wRequest.ContentType = "application/json";
      wRequest.Method = WebRequestMethods.Http.Post;

      wRequest.Headers.Add($"Authorization:key={apiKey}");

      using (var reqStream = await wRequest.GetRequestStreamAsync())
      using (var streamWriter = new StreamWriter(reqStream))
      {
        string json = JSON.SerializeDynamic(requestMessage, Options.IncludeInherited);

        await streamWriter.WriteAsync(json);
      }

      var retryStrategy = new ExponentialBackoff(3, TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(20), TimeSpan.FromSeconds(1));

      var retryPolicy = new RetryPolicy<WebExceptionDetectionStrategy>(retryStrategy);

      return await retryPolicy.ExecuteAction(async () =>
      {
        using (var httpResponse = await wRequest.GetResponseAsync())
        using (var responseStream = httpResponse.GetResponseStream())
        using (var streamReader = new StreamReader(responseStream))
        {
          return await streamReader.ReadToEndAsync();
        }
      });
    }
  }

  class WebExceptionDetectionStrategy : ITransientErrorDetectionStrategy
  {
    public bool IsTransient(Exception ex)
    {
      WebException wException = ex as WebException;

      if (wException != null)
      {
        var response = wException.Response as HttpWebResponse;

        if (response != null)
        {
          HttpStatusCode statusCode = response.StatusCode;

          return statusCode == HttpStatusCode.GatewayTimeout || statusCode == HttpStatusCode.RequestTimeout || statusCode == HttpStatusCode.ServiceUnavailable;
        }
      }

      return false;
    }
  }
}
