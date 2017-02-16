using Jil;
using System.Collections.Generic;

namespace FcmSharp.MessageEntities.Request
{
  internal class DataMessage : Message
  {
    public DataMessage(MessageOptions options, List<string> registrationdIds, object data) : this(options, registrationdIds, data, null)
    {

    }

    public DataMessage(MessageOptions options, List<string> registrationdIds, object data, NotificationPayload notification) : base(options, registrationdIds)
    {
      Data = data;
      Notification = notification;
    }

    public DataMessage(MessageOptions options, string to, object data) : this(options, to, data, null)
    {
      
    }

    public DataMessage(MessageOptions options, string to, object data, NotificationPayload notification) : base(options, to)
    {
      Data = data;
      Notification = notification;
    }

    [JilDirective("data")]
    public object Data { get; private set; }

    [JilDirective("notification")]
    public NotificationPayload Notification { get; private set; }
  }
}
