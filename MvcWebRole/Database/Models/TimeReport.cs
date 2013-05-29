using MvcWebRole.Database.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWebRole.Database.Models
{
    [Table("TimeReports")]
    public class TimeReport : IEntity
    {
        [Key]
        public int id { get; set; }

        public int? assignmentId { get; set; }

        public int? performerId { get; set; }

        public int hours { get; set; }

        public int minutes { get; set; }

        [ForeignKey("assignmentId")]
        public virtual Assignment assignment { get; set; }

        [ForeignKey("performerId")]
        public virtual Performer performer { get; set; }

        public DateTime? updated { get; set; }

        public DateTime? created { get; set; }

        public DateTime? startReport { get; set; }

        public DateTime? endReport { get; set; }

    }
}
