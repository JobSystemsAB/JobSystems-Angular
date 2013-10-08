using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PageAndServices.Helpers
{
    public class Address
    {
        public string streetNumber { get; set; }

        public string street { get; set; }

        public string postalCode { get; set; }

        public string postalTown { get; set; }

        public string country { get; set; }

        public double longitude { get; set; }

        public double latitude { get; set; }
    }
}