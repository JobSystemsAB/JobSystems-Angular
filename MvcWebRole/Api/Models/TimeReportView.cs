using MvcWebRole.Api.Structs;
using MvcWebRole.Database.Helper;
using MvcWebRole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole.Api.Models
{
    public class TimeReportView
    {
        public int id { get; set; }

        public int assignmentId { get; set; }

        public int performerId { get; set; }

        public int hours { get; set; }

        public int minutes { get; set; }

        public AssignmentInfo assignmentInfo { get; set; }

        public PerformerInfo performerInfo { get; set; }

        public string updated { get; set; }

        public string created { get; set; }

        //public string startDate { get; set; }

        //public string startTime { get; set; }

        //public string endDate { get; set; }

        //public string endTime { get; set; }





        public TimeReportView()
        {
        }

        public TimeReportView(TimeReport timeReport)
        {
            AutoMapper.Mapper.CreateMap<TimeReport, TimeReportView>();
            AutoMapper.Mapper.Map<TimeReport, TimeReportView>(timeReport, this);

            this.created = timeReport.created.ToString().Replace('T', ' ');
            this.updated = timeReport.updated.ToString().Replace('T', ' ');

            //if (timeReport.startReport != null)
            //{
            //    var startDateTime = timeReport.startReport.ToString().Split(' ');
            //    this.startDate = startDateTime[0];
            //    this.startTime = startDateTime[1].Substring(0, startDateTime[1].LastIndexOf(':') + 1);
            //}

            //if (timeReport.endReport != null)
            //{
            //    var endDateTime = timeReport.endReport.ToString().Split(' ');
            //    this.endDate = endDateTime[0];
            //    this.endTime = endDateTime[1].Substring(0, endDateTime[1].LastIndexOf(':') + 1);
            //}

            if (timeReport.performer != null)
            {
                this.performerInfo = new PerformerInfo();
                AutoMapper.Mapper.CreateMap<Performer, PerformerInfo>();
                AutoMapper.Mapper.Map<Performer, PerformerInfo>(timeReport.performer, this.performerInfo);
            }

            if (timeReport.assignment != null)
            {
                this.assignmentInfo = new AssignmentInfo();
                AutoMapper.Mapper.CreateMap<Assignment, AssignmentInfo>();
                AutoMapper.Mapper.Map<Assignment, AssignmentInfo>(timeReport.assignment, this.assignmentInfo);

                if (timeReport.assignment.client != null)
                {
                    this.assignmentInfo.clientInfo = new ClientInfo();
                    AutoMapper.Mapper.CreateMap<Client, ClientInfo>();
                    AutoMapper.Mapper.Map<Client, ClientInfo>(timeReport.assignment.client, this.assignmentInfo.clientInfo);
                }
            }
        }

        public TimeReport convert(EntityFrameworkContext context)
        {
            var assignmentTimeReport = new TimeReport();

            AutoMapper.Mapper.CreateMap<TimeReportView, TimeReport>();
            AutoMapper.Mapper.Map<TimeReportView, TimeReport>(this, assignmentTimeReport);

            return assignmentTimeReport;
        }
    }
}