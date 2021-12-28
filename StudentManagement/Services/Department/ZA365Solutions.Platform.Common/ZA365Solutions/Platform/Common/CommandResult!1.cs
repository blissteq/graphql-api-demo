namespace ZA365Solutions.Platform.Common
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [DataContract]
    public class CommandResult<T> : CommandResult where T : new()
    {
        [DataMember(Name = "resource")]
        public T Resource { get; set; }

        public CommandResult(Guid resourceId, T resource, bool accepted)
          : base(resourceId, accepted)
        {
            this.Resource = resource;
        }
    }
}

