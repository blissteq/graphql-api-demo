namespace ZA365Solutions.Platform.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using ZA365Solutions.Platform.Common.Enums;

    public class ValidationResult
    {
        private readonly List<ResultMessage> _messages;

        public ValidationResult() => this._messages = new List<ResultMessage>();

        public bool IsValid => !this._messages.Any<ResultMessage>((Func<ResultMessage, bool>)(m => m.MessageType == ResultMessageType.Error));

        public IEnumerable<ResultMessage> ValidationMessages => (IEnumerable<ResultMessage>)this._messages;

        public void AddValidationMessage(ResultMessageType validationType, string code, string message) => this._messages.Add(new ResultMessage(validationType, code, message));
    }
}

