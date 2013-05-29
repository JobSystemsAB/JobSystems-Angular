using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole.Api.Structs
{
    public class AssignmentInfo
    {
        public int id { get; set; }

        public ClientInfo clientInfo { get; set; }

        public AssignmentInfo() 
        {
 
        }
    }
}