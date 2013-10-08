using PageAndServices.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    [Table("Testimonials")]
    public class Testimonial : IEntity
    {
        [Key, Column("testimonial_id")]
        public int id { get; set; }

        public string text { get; set; }

        public string name { get; set; }

        public string language { get; set; }

        public DateTime created { get; set; }

        public bool enabled { get; set; }
    }
}