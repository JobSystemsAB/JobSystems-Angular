using PageAndServices.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    [Table("CategoryInputs")]
    public class CategoryInput : IEntity
    {
        [Key, Column("category_input_id")]
        public int id { get; set; }

        public string name { get; set; }

        public string text { get; set; }

        public string type { get; set; }

        #region NAVIGATION PROPERTIES

        public virtual Category category { get; set; }

        #endregion
    }
}