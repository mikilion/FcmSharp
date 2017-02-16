namespace FcmSharp.MessageEntities.Request
{
  /// <summary>
  /// Delivery priority to downstream messages values
  /// </summary>
  public enum MessagePriority
  {
    /// <summary>
    /// This is the default priority for data messages.
    /// </summary>
    normal,

    /// <summary>
    /// This is the default priority for notification messages.
    /// </summary>
    high,
  }
}
