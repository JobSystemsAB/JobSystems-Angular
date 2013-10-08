using PageAndServices.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    [Table("WorkShifts")]
    public class WorkShift : IEntity
    {
        [Key, Column("work_shift_id")]
        public int id { get; set; }

        public TimeSpan span { get; set; }

        public DateTime date { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }


        #region NAVIGATION PROPERTIES

        public virtual Employee employee { get; set; }

        public virtual Mission mission { get; set; }

        #endregion

    }
}