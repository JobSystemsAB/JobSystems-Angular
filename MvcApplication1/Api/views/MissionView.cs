using AutoMapper;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class MissionView
    {
        public int id { get; set; }

        public int customerId { get; set; }

        public int? employeeId { get; set; }

        public string description { get; set; }

        public string created { get; set; }

        public bool enabled { get; set; }

        public Address address { get; set; }



        public MissionView()
        {
        }

        public MissionView(Mission input)
        {
            Mapper.CreateMap<Mission, MissionView>();
            Mapper.Map<Mission, MissionView>(input, this);

            this.created = input.created.ToString().Replace('T', ' ');
            this.employeeId = input.employee == null ? null : (int?)input.employee.id;
            this.customerId = input.customer.id;
        }

        public Mission convert(EntityFrameworkContext context)
        {
            var output = new Mission();

            Mapper.CreateMap<MissionView, Mission>();
            Mapper.Map<MissionView, Mission>(this, output);

            output.employee = this.employeeId == null ? null : context.employees.FirstOrDefault(e => e.id == this.employeeId);
            output.customer = this.customerId == null ? null : context.customers.FirstOrDefault(c => c.id == this.customerId);

            return output;
        }
    }
}