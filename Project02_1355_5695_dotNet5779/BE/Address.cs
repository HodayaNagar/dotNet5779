using System;

namespace BE
{
    public class Address
    {
        public String City { get; set; }
        public String StreetName { get; set; }
        public int BuildingNumber { get; set; }

        public override string ToString()
        {
            return $"city : {City} street name : {StreetName} building number : {BuildingNumber}";
        }
    }
}
