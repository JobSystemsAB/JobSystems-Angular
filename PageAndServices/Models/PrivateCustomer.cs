using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    public class PrivateCustomer : Customer
    {

        [Column("first_name")]
        public string firstName { get; set; }

        [Column("last_name")]
        public string lastName { get; set; }

        [Column("personal_number")]
        public string personalNumber { get; set; }

        [Column("property_name")]
        public string propertyName { get; set; }
    
    }
}