using MvcWebRole.Database.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWebRole.Database.Models
{
    [Table("Categories")]
    public class Category : IEntity
    {
        public Category()
        {
            knowledges = new HashSet<Knowledge>();
        }

        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public virtual ICollection<Knowledge> knowledges { get; set; }
    }
}