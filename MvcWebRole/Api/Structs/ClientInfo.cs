using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole.Api.Structs
{
    public class ClientInfo
    {
        public int id { get; set; }

        public string organisationNumber { get; set; }

        public string companyName { get; set; }

        public ClientInfo() 
        { 
        
        }
    }
}