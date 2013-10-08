using PageAndServices.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    [Table("Texts")]
    public class Text : IEntity
    {
        [Key, Column("text_id")]
        public int id { get; set; }

        [Column("controller_name")]
        public string controllerName { get; set; }

        [Column("element_id")]
        public string elementId { get; set; }

        public string language { get; set; }

        public string text { get; set; }

        public bool enabled { get; set; }

        public DateTime created { get; set; }
    }
}