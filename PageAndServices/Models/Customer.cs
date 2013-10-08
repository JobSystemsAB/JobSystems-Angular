using PageAndServices.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    [Table("Customers")]
    public class Customer : IEntity
    {

        [Key, Column("customer_id")]
        public int id { get; set; }

        public Guid fakeId { get; set; }

        [Column("email_address")]
        public string emailAddress { get; set; }

        [Column("phone_number")]
        public string phoneNumber { get; set; }

        public string password { get; set; }
        
        public DateTime created { get; set; }

        public DateTime updated { get; set; }

        public bool enabled { get; set; }


        #region NAVIGATION PROPERTIES

        public Customer()
        {
            missions = new HashSet<Mission>();
            comments = new HashSet<Comment>();
        }

        public virtual ICollection<Mission> missions { get; set; }

        public virtual ICollection<Comment> comments { get; set; }

        #endregion

    }
}