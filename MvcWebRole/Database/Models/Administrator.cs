using MvcWebRole.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWebRole.Database.Models
{
    [Table("Administrators")]
    public class Administrator
    {
        [Key]
        public int id { get; set; }

        public int? accessTokenId { get; set; }

        [ForeignKey("accessTokenId")]
        public virtual AdministratorAccessToken accessToken { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string emailAddress { get; set; }

        public DateTime? created { get; set; }

        public bool enabled { get; set; }
    }
}