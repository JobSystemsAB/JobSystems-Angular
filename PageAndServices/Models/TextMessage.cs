using PageAndServices.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    [Table("TextMessages")]
    public class TextMessage : IEntity
    {
        [Key, Column("text_id")]
        public int id { get; set; }

        public string from { get; set; }

        public string to { get; set; }

        public string message { get; set; }

        [Column("api_id")]
        public string apiId { get; set; }
        
        [Column("error_message")]
        public string errorMessage { get; set; }

        public string status { get; set; }

        public bool error { get; set; }

        public DateTime created { get; set; }

        public DateTime? delivered { get; set; }
    }
}