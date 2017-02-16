using Jil;

namespace FcmSharp.MessageEntities.Response
{
  /// <summary>
  /// Message Response Status
  /// </summary>
  public class MessageResponseStatus
  {
    /// <summary>
    /// Specifying a unique ID for each successfully processed message
    /// </summary>
    [JilDirective("message_id")]
    public string MessageId { get; set; }

    /// <summary>
    /// Specifying the canonical registration token for the client app that the message was processed and sent to.
    /// </summary>
    [JilDirective("registration_id")]
    public string RegistrationId { get; set; }

    /// <summary>
    /// Specifying the error that occurred when processing the message for the recipient.
    /// </summary>
    public ErrorResponseCode Error { get; set; }
  }
}
