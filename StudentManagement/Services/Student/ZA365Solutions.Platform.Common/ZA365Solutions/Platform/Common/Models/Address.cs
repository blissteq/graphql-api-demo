namespace ZA365Solutions.Platform.Common.Models
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [DataContract]
    public class Address
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "addressLine1")]
        public string AddressLine1 { get; set; }

        [DataMember(Name = "addressLine2")]
        public string AddressLine2 { get; set; }

        [DataMember(Name = "township")]
        public string Township { get; set; }

        [DataMember(Name = "cityTown")]
        public string CityTown { get; set; }

        [DataMember(Name = "province")]
        public string Province { get; set; }

        [DataMember(Name = "postalCode")]
        public string PostalCode { get; set; }

        [DataMember(Name = "countryCode")]
        public string CountryCode { get; set; }
    }
}

