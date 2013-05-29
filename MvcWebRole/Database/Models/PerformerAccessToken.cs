using MvcWebRole.Database.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWebRole.Database.Models
{
    [Table("PerformerAccessTokens")]
    public class PerformerAccessToken : IEntity
    {
        [Key, ForeignKey("performer")]
        public int id { get; set; }

        public int? performerId { get; set; }

        [ForeignKey("performerId")]
        public virtual Performer performer { get; set; }

        public Guid accessToken { get; set; }

        public DateTime created { get; set; }
    }
}