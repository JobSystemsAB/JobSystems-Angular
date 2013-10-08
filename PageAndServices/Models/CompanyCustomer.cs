using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    public class CompanyCustomer : Customer
    {

        [Column("organisation_number")]
        public string organisationNumber { get; set; }

        [Column("company_name")]
        public string companyName { get; set; }

    }
}