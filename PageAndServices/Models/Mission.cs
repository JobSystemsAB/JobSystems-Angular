using PageAndServices.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    [Table("Missions")]
    public class Mission : IEntity
    {

        [Key, Column("mission_id")]
        public int id { get; set; }

        public Guid fakeId { get; set; }

        public int? hours { get; set; }

        public string description { get; set; }

        public string extras { get; set; }

        public Address address { get; set; }

        public DateTime? date { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }

        public bool enabled { get; set; }


        #region NAVIGATION PROPERTIES

        public Mission()
        {
            workShifts = new HashSet<WorkShift>();
            comments = new HashSet<Comment>();
            categories = new HashSet<Category>();
        }

        public virtual Customer customer { get; set; }

        public virtual Employee employee { get; set; }

        public virtual ICollection<Category> categories { get; set; }

        public virtual ICollection<WorkShift> workShifts { get; set; }

        public virtual ICollection<Comment> comments { get; set; }

        #endregion

    }
}