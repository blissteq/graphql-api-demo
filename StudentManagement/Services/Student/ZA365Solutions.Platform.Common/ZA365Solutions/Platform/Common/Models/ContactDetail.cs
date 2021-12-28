namespace ZA365Solutions.Platform.Common.Models
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [DataContract]
    public class ContactDetail
    {
        [DataMember(Name="contactType")]
        public string ContactType { get; set; }

        [DataMember(Name="contact")]
        public string Contact { get; set; }
    }
}

