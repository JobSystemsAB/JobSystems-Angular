using AutoMapper;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class EmployeeView
    {

        public int id { get; set; }

        public string infoText { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string emailAddress { get; set; }

        public string mobilePhoneNumber { get; set; }

        public string phoneNumber { get; set; }

        public string bankName { get; set; }

        public string bankClearingNumber { get; set; }

        public string bankAccountNumber { get; set; }

        public string hourSalary { get; set; }

        public string password { get; set; }

        public string personalNumber { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

        public Address address { get; set; }

        public bool enabled { get; set; }

        public bool sendSms { get; set; }

        public bool sendMail { get; set; }



        // -- CONSTRUCTOR --

        public EmployeeView()
        {
        }

        public EmployeeView(Employee input)
        {
            Mapper.CreateMap<Employee, EmployeeView>();
            Mapper.Map<Employee, EmployeeView>(input, this);

            this.created = input.created.ToString().Replace('T', ' ');
            this.updated = input.updated.ToString().Replace('T', ' ');
        }

        public Employee convert(EntityFrameworkContext context)
        {
            var output = new Employee();

            Mapper.CreateMap<EmployeeView, Employee>();
            Mapper.Map<EmployeeView, Employee>(this, output);

            return output;
        }
    }
}