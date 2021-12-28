namespace ZA365Solutions.Platform.Common
{
    using System;
    using System.Runtime.Serialization;
    using ZA365Solutions.Platform.Common.Enums;
    [DataContract]
    public class ResultMessage
    {
        private readonly string _code;
        private readonly string _message;
        private ResultMessageType _messageType;

        public ResultMessage(ResultMessageType messageType, string code, string message)
        {
            this._messageType = messageType;
            this._code = code;
            this._message = message;
        }

        [DataMember(Name = "messageType")]
        public ResultMessageType MessageType => this._messageType;

        [DataMember(Name = "message")]
        public string Message => this._message;

        [DataMember(Name = "code")]
        public string Code => this._code;
    }
}

