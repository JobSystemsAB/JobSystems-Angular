using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole.Api.Structs
{
    public class PerformerInfo
    {
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime? birthDate { get; set; }
    }
}