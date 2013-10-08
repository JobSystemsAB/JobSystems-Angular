using PageAndServices.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    [Table("Administrators")]
    public class Administrator : IEntity
    {

        [Key, Column("administrator_id")]
        public int id { get; set; }

        [Column("fake_id")]
        public Guid fakeId { get; set; }

        [Column("auth_token")]
        public Guid authToken { get; set; }

        public string password { get; set; }

        [Column("email_address")]
        public string emailAddress { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }

        public bool enabled { get; set; }
    
    }
}