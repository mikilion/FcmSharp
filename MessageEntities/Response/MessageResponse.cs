using Jil;
using System.Collections.Generic;

namespace FcmSharp.MessageEntities.Response
{
  /// <summary>
  /// Downstream HTTP message response
  /// </summary>
  public class MessageResponse
  {
    /// <summary>
    /// Number of messages that were processed without an error.
    /// </summary>
    public int Success { get; set; }

    /// <summary>
    /// Number of messages that could not be processed.
    /// </summary>
    public int Failure { get; set; }

    /// <summary>
    /// Unique ID (number) identifying the multicast message.
    /// </summary>
    [JilDirective("multicast_id")]
    public ulong MulticastId { get; set; }

    /// <summary>
    /// Array of objects representing the status of the messages processed.
    /// </summary>
    public List<MessageResponseStatus> Results { get; set; }
  }
}
