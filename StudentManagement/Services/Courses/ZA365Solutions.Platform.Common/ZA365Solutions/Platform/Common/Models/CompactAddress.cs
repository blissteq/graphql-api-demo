namespace ZA365Solutions.Platform.Common.Models
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [DataContract]
    public class CompactAddress
    {
        [DataMember(Name="description")]
        public string Description { get; set; }

        [DataMember(Name="detail")]
        public string Detail { get; set; }

        [DataMember(Name="postalCode")]
        public string PostalCode { get; set; }

        [DataMember(Name="countryCode")]
        public string CountryCode { get; set; }
    }
}

