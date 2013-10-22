using PageAndServices.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    [Table("Employees")]
    public class Employee : IEntity
    {

        [Key, Column("employee_id")]
        public int id { get; set; }

        public Guid fakeId { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Column("first_name")]
        public string firstName { get; set; }

        [Column("last_name")]
        public string lastName { get; set; }

        [Column("email_address")]
        public string emailAddress { get; set; }

        [Column("phone_number")]
        public string phoneNumber { get; set; }

        [Column("personal_number")]
        public string personalNumber { get; set; }

        [Column("bank_name")]
        public string bankName { get; set; }

        [Column("bank_clreaing_number")]
        public string bankClearingNumber { get; set; }

        [Column("bank_account_number")]
        public string bankAccountNumber { get; set; }

        public string password { get; set; }

        public Address address { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }

        public bool enabled { get; set; }


        #region NAVIGATION PROPERTIES

        public Employee()
        {
            missions = new HashSet<Mission>();
            categories = new HashSet<Category>();
            workShifts = new HashSet<WorkShift>();
            comments = new HashSet<Comment>();
        }

        public virtual ICollection<Mission> missions { get; set; }

        public virtual ICollection<Category> categories { get; set; }

        public virtual ICollection<WorkShift> workShifts { get; set; }

        public virtual ICollection<Comment> comments { get; set; }

        //[InverseProperty("Employee")]
        //public virtual EmployeePet petEmployee { get; set; }

        #endregion

    }
}