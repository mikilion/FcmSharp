namespace FcmSharp.MessageEntities.Request
{
  public class MessageOptions
  {
    /// <summary>
    /// When there is a newer message that renders an older, related message irrelevant to the client app, FCM replaces the older message. For example: send-to-sync, or outdated notification messages.
    /// </summary>
    public string CollapseKey { get; set; }

    /// <summary>
    /// Sets the priority of the message. Valid values are "normal" and "high." On iOS, these correspond to APNs priorities 5 and 10.
    /// </summary>
    public MessagePriority Priority { get; set; }

    /// <summary>
    /// On iOS, use this field to represent content-available in the APNs payload. When a notification or message is sent and this is set to true, an inactive client app is awoken. On Android, data messages wake the app by default. On Chrome, currently not supported.
    /// </summary>
    public bool ContentAvailable { get; set; }

    /// <summary>
    /// This parameter specifies how long (in seconds) the message should be kept in FCM storage if the device is offline. The maximum time to live supported is 4 weeks, and the default value is 4 weeks.
    /// </summary>
    public int TimeToLive { get; set; }

    /// <summary>
    /// This parameter specifies the package name of the application where the registration tokens must match in order to receive the message.
    /// </summary>
    public string RestrictedPackageName { get; set; }

    /// <summary>
    /// This parameter, when set to true, allows developers to test a request without actually sending a message.
    /// </summary>
    public bool DryRun { get; set; }
  }
}
