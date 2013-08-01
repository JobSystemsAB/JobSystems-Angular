using AutoMapper;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class CustomerCompanyView
    {

        public int id { get; set; }

        public string emailAddress { get; set; }

        public string phoneNumber { get; set; }

        public string password { get; set; }

        public Address address { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

        public bool enabled { get; set; }



        public string organisationNumber { get; set; }

        public string companyName { get; set; }



        // -- CONSTRUCTOR --

        public CustomerCompanyView()
        {
        }

        public CustomerCompanyView(CustomerCompany input)
        {
            Mapper.CreateMap<CustomerCompany, CustomerCompanyView>();
            Mapper.Map<CustomerCompany, CustomerCompanyView>(input, this);

            this.created = input.created.ToString().Replace('T', ' ');
            this.updated = input.updated.ToString().Replace('T', ' ');
        }

        public CustomerCompany convert(EntityFrameworkContext context)
        {
            var output = new CustomerCompany();

            Mapper.CreateMap<CustomerPrivateView, CustomerPrivate>();
            Mapper.Map<CustomerCompanyView, CustomerCompany>(this, output);

            return output;
        }
    }
}