using PageAndServices.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    [Table("Comments")]
    public class Comment : IEntity
    {
        [Key, Column("comment_id")]
        public int id { get; set; }

        public string text { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }

        #region NAVIGATION PROPERTIES

        public virtual Customer customer { get; set; }

        public virtual Employee employee { get; set; }

        public virtual Mission mission { get; set; }

        #endregion

    }
}