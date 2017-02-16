using Jil;

namespace FcmSharp.MessageEntities.Request
{
  /// <summary>
  /// Specifies the predefined, user-visible key-value pairs of the notification payload.
  /// </summary>
  public class NotificationPayload
  {
    /// <summary>
    /// The notification's title. 
    /// </summary>
    [JilDirective("title")]
    public string Title { get; set; }

    /// <summary>
    /// The notification's body text. 
    /// </summary>
    [JilDirective("body")]
    public string Body { get; set; }

    /// <summary>
    /// The notification's icon. 
    /// </summary>
    [JilDirective("icon")]
    public string Icon { get; set; }

    /// <summary>
    /// The sound to play when the device receives the notification. 
    /// </summary>
    [JilDirective("sound")]
    public string Sound { get; set; }

    /// <summary>
    /// The value of the badge on the home screen app icon. 
    /// </summary>
    [JilDirective("badge")]
    public string Badge { get; set; }

    /// <summary>
    /// Identifier used to replace existing notifications in the notification drawer.
    /// </summary>
    [JilDirective("tag")]
    public string Tag { get; set; }

    /// <summary>
    /// The notification's icon color, expressed in #rrggbb format. 
    /// </summary>
    [JilDirective("color")]
    public string Color { get; set; }
  }
}
