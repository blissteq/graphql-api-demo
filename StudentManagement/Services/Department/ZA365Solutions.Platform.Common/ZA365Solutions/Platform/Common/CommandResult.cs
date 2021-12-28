namespace ZA365Solutions.Platform.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using ZA365Solutions.Platform.Common.Enums;

    [DataContract]
    public class CommandResult
    {
        protected readonly List<ResultMessage> _messages;

        [DataMember(Name = "accepted")]
        public bool Accepted { get; }

        [DataMember(Name = "resourceId")]
        public Guid? ResourceId { get; }

        public CommandResult(Guid resourceId, bool accepted)
        {
            this.ResourceId = new Guid?(resourceId);
            this.Accepted = accepted;
            this._messages = new List<ResultMessage>();
        }

        [DataMember(Name = "messages")]
        public IEnumerable<ResultMessage> Messages => (IEnumerable<ResultMessage>)this._messages;

        public void AddResultMessage(ResultMessageType messageType, string code, string message) => this._messages.Add(new ResultMessage(messageType, code, message));
    }

}

