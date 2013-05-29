using MvcWebRole.Database.Helper;
using MvcWebRole.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWebRole.Api.Models
{
    [Table("AdministratorAccessTokens")]
    public class AdministratorAccessToken : IEntity
    {
        [Key, ForeignKey("administrator")]
        public int id { get; set; }

        public int? administratorId { get; set; }

        [ForeignKey("administratorId")]
        public virtual Administrator administrator { get; set; }

        public Guid accessToken { get; set; }

        public DateTime created { get; set; }
    }
}