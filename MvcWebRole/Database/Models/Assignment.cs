using MvcWebRole.Database.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWebRole.Database.Models
{
    [Table("Assignments")]
    public class Assignment : IEntity
    {
        public Assignment()
        {
            performers = new HashSet<Performer>();
            timeReports = new HashSet<TimeReport>();
            knowledges = new HashSet<Knowledge>();
        }

        [Key]
        public int id { get; set; }

        public int? clientId { get; set; }

        [ForeignKey("clientId")]
        public virtual Client client { get; set; }

        public virtual ICollection<Performer> performers { get; set; }

        public virtual ICollection<TimeReport> timeReports { get; set; }

        public virtual ICollection<Knowledge> knowledges { get; set; }

        public DateTime? created { get; set; }

        public DateTime? updated { get; set; }

        public bool? enabled { get; set; }

        public string description { get; set; }
    }
}