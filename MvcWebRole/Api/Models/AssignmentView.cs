using MvcWebRole.Api.Structs;
using MvcWebRole.Database.Helper;
using MvcWebRole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole.Api.Models
{
    public class AssignmentView
    {
        public int id { get; set; }

        public int? clientId { get; set; }

        public ClientInfo clientInfo { get; set; }

        public IEnumerable<int> performerIds { get; set; }

        public IEnumerable<int> timeReportsIds { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

        public bool? enabled { get; set; }

        public string description { get; set; }

        public string password { get; set; }




        public string displayName { get { return this.clientInfo.companyName + " (" + this.clientInfo.organisationNumber + ") - " + this.description; } }





        public AssignmentView()
        {
        }

        public AssignmentView(Assignment assignment)
        {
            AutoMapper.Mapper.CreateMap<Assignment, AssignmentView>();
            AutoMapper.Mapper.Map<Assignment, AssignmentView>(assignment, this);
            this.performerIds = assignment.performers.Select(p => p.id);
            this.timeReportsIds = assignment.timeReports.Select(a => a.id);

            if (assignment.client != null)
            {
                this.clientInfo = new ClientInfo();
                AutoMapper.Mapper.CreateMap<Client, ClientInfo>();
                AutoMapper.Mapper.Map<Client, ClientInfo>(assignment.client, this.clientInfo);
            }

            this.created = assignment.created.ToString().Replace('T', ' ');
            this.updated = assignment.updated.ToString().Replace('T', ' ');
        }

        public Assignment convert(EntityFrameworkContext context)
        {
            var assignment = new Assignment();

            AutoMapper.Mapper.CreateMap<AssignmentView, Assignment>();
            AutoMapper.Mapper.Map<AssignmentView, Assignment>(this, assignment);

            if (this.performerIds != null)
                foreach (var performer in context.performers.Where(p => this.performerIds.Contains(p.id)))
                    assignment.performers.Add(performer);
            if (this.timeReportsIds != null)
                foreach (var assignmentTimeReport in context.timeReports.Where(a => this.timeReportsIds.Contains(a.id)))
                    assignment.timeReports.Add(assignmentTimeReport);
            if (this.clientId != null)
                assignment.client = context.clients.FirstOrDefault(c => c.id == this.clientId);

            return assignment;
        }
    }
}