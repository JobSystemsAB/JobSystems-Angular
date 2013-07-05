using MvcWebRole.Database.Helper;
using MvcWebRole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole.Api.Models
{
    public class PerformerView
    {
        public int id { get; set; }

        public virtual IEnumerable<int> assignmentIds { get; set; }

        public virtual IEnumerable<int> timeReportIds { get; set; }

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

        public string newPassword { get; set; }

        public bool? enabled { get; set; }

        public string birthDate { get; set; }

        public string startDate { get; set; }

        public string updated { get; set; }

        public string created { get; set; }





        public string displayName { get { return this.firstName + " " + this.lastName + " (" + this.birthDate.ToString() + ")"; } }





        public PerformerView()
        {
        }

        public PerformerView(Performer performer)
        {
            AutoMapper.Mapper.CreateMap<Performer, PerformerView>();
            AutoMapper.Mapper.Map<Performer, PerformerView>(performer, this);
            this.assignmentIds = performer.assignments.Select(p => p.id);
            this.timeReportIds = performer.timeReports.Select(a => a.id);

            this.birthDate = performer.birthDate.ToString().Replace('T', ' ');
            this.startDate = performer.startDate.ToString().Replace('T', ' ');
            this.updated = performer.updated.ToString().Replace('T', ' ');
            this.created = performer.created.ToString().Replace('T', ' ');
        }

        public Performer convert(EntityFrameworkContext context)
        {
            var performer = new Performer();

            AutoMapper.Mapper.CreateMap<PerformerView, Performer>();
            AutoMapper.Mapper.Map<PerformerView, Performer>(this, performer);

            if (this.assignmentIds != null)
                foreach (var assignment in context.assignments.Where(a => this.assignmentIds.Contains(a.id)))
                    performer.assignments.Add(assignment);
            if (this.timeReportIds != null)
                foreach (var assignmentTimeReport in context.performerTimeReports.Where(a => this.timeReportIds.Contains(a.id)))
                    performer.timeReports.Add(assignmentTimeReport);

            return performer;
        }
    }
}