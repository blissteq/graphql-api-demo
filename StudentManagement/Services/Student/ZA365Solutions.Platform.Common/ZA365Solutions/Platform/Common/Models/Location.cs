namespace ZA365Solutions.Platform.Common.Models
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [DataContract]
    public class Location
    {
        [DataMember(Name="longitude")]
        public string Longitude { get; set; }

        [DataMember(Name="lattitude")]
        public string Lattitude { get; set; }

        [DataMember(Name="description")]
        public string Description { get; set; }

        [DataMember(Name="address")]
        public ZA365Solutions.Platform.Common.Models.Address Address { get; set; }
    }
}

