using MvcWebRole.Api.Models;
using MvcWebRole.Database.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWebRole.Database.Models
{
    [Table("Performers")]
    public class Performer : IEntity
    {
        public Performer()
        {
            assignments = new HashSet<Assignment>();
            timeReports = new HashSet<TimeReport>();
        }

        [Key]
        public int id { get; set; }

        public int? accessTokenId { get; set; }

        [ForeignKey("accessTokenId")]
        public virtual PerformerAccessToken accessToken { get; set; }

        public virtual ICollection<Assignment> assignments { get; set; }

        public virtual ICollection<TimeReport> timeReports { get; set; }

        public string infoText { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string emailAddress { get; set; }

        public string mobilePhoneNumber { get; set; }

        public string phoneNumber { get; set; }

        public string streetAddress { get; set; }

        public string postalCode { get; set; }

        public string postTown { get; set; }

        public string country { get; set; }

        public string bankName { get; set; }

        public string bankClearingNumber { get; set; }

        public string bankAccountNumber { get; set; }

        public string fulltimeSalary { get; set; }

        public string hourSalary { get; set; }

        public string unsocialHoursBonusSimple { get; set; }

        public string unsocialHoursBonusQualified { get; set; }

        public string unsocialHoursBonusHoliday { get; set; }

        public string travelCompensation { get; set; }

        public string taxTable { get; set; }

        public string taxColumn { get; set; }

        public string password { get; set; }

        public bool? enabled { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? birthDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? startDate { get; set; }

        public DateTime? updated { get; set; }

        public DateTime? created { get; set; }

    }
}