using MvcWebRole.Database.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWebRole.Database.Models
{
    [Table("Clients")]
    public abstract class Client : IEntity
    {
        public Client() 
        {
            assignments = new HashSet<Assignment>();
        }

        [Key]
        public int id { get; set; }

        public virtual IEnumerable<Assignment> assignments { get; set; }

        public string streetAddress { get; set; }

        public string streetAddress2 { get; set; }

        public string postalCode { get; set; }

        public string postTown { get; set; }

        public string country { get; set; }

        public string emailAddress { get; set; }

        public string phoneNumber { get; set; }

        public string SNI { get; set; }

        public string password { get; set; }

        public DateTime? created { get; set; }

        public DateTime? updated { get; set; }

        public bool? enabled { get; set; }
    }
}