using PageAndServices.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    [Table("Categories")]
    public class Category : IEntity
    {
        [Key, Column("category_id")]
        public int id { get; set; }

        public int salary { get; set; }

        public int order { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string url { get; set; }

        #region NAVIGATION PROPERTIES

        public Category()
        {
            children = new HashSet<Category>();
            missions = new HashSet<Mission>();
            employees = new HashSet<Employee>();
            categoryInputs = new HashSet<CategoryInput>();
        }

        public virtual Category parent { get; set; }

        public virtual ICollection<Category> children { get; set; }

        public virtual ICollection<Mission> missions { get; set; }

        public virtual ICollection<Employee> employees { get; set; }

        public virtual ICollection<CategoryInput> categoryInputs { get; set; }

        #endregion

    }
}