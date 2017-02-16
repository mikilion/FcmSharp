using Jil;
using System.Collections.Generic;

namespace FcmSharp.MessageEntities.Request
{
  /// <summary>
  /// Downstream message
  /// </summary>
  internal abstract class Message
  {
    private MessageOptions options;

    Message(MessageOptions options)
    {
      this.options = options;
    }

    public Message(MessageOptions options, string to) : this(options)
    {
      To = to;
    }

    public Message(MessageOptions options, List<string> registrationdIds) : this(options)
    {
      RegistrationIds = registrationdIds;
    }    

    /// <summary>
    /// This parameter specifies the recipient of a message. 
    /// </summary>
    [JilDirective("to")]
    public string To { get; private set; }

    /// <summary>
    /// This parameter specifies a list of devices (registration tokens, or IDs) receiving a multicast message. It must contain at least 1 and at most 1000 registration tokens.
    /// </summary>
    [JilDirective("registration_ids")]
    public List<string> RegistrationIds { get; private set; }

    /// <summary>
    /// This parameter specifies a logical expression of conditions that determine the message target.
    /// </summary>
    [JilDirective("condition")]
    public string Condition { get; set; }

    [JilDirective("collapse_key")]
    public string CollapseKey { get { return options.CollapseKey; } }

    [JilDirective("priority")]
    public MessagePriority Priority { get { return options.Priority; } }

    [JilDirective("content_available")]
    public bool ContentAvailable { get { return options.ContentAvailable; } }

    [JilDirective("time_to_live")]
    public int TimeToLive { get { return options.TimeToLive; } }

    [JilDirective("restricted_package_name")]
    public string RestrictedPackageName { get { return options.RestrictedPackageName; } }

    [JilDirective("dry_run")]
    public bool DryRun { get { return options.DryRun; } }
  }
}
