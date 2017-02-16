using System;

namespace FcmSharp.MessageEntities.Response
{
  /// <summary>
  /// Downstream message error response codes.
  /// </summary>
  [Flags]
  public enum ErrorResponseCode
  {
    Unknown = 0,

    /// <summary>
    /// Not registered token
    /// </summary>
    NotRegistered,

    /// <summary>
    /// Check that the total size of the payload data included in a message does not exceed FCM limits: 4096 bytes for most messages,
    /// or 2048 bytes in the case of messages to topics or notification messages on iOS. This includes both the keys and the values.
    /// </summary>
    MessageTooBig,

    /// <summary>
    /// The rate of messages to subscribers to a particular topic is too high. Reduce the number of messages sent for this topic, and do not immediately retry sending.
    /// </summary>
    TopicsMessageRateExceeded,

    /// <summary>
    /// Check the format of the registration token you pass to the server.
    /// </summary>
    InvalidRegistration,
  }
}
