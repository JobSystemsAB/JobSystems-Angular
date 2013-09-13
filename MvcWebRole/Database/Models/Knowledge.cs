using MvcWebRole.Database.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWebRole.Database.Models
{
    [Table("Knowledges")]
    public class Knowledge : IEntity
    {
        public Knowledge()
        {
            assignments = new HashSet<Assignment>();
            performers = new HashSet<Performer>();
        }

        [Key]
        public int id { get; set; }

        public int categoryId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        [ForeignKey("categoryId")]
        public virtual KnowledgeCategory category { get; set; }

        public virtual IEnumerable<Assignment> assignments { get; set; }

        public virtual IEnumerable<Performer> performers { get; set; }
    }
}