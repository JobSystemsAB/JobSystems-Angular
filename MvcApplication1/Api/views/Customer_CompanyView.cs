using AutoMapper;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class Customer_CompanyView
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

        public Customer_CompanyView()
        {
        }

        public Customer_CompanyView(Customer_Company input)
        {
            Mapper.CreateMap<Customer_Company, Customer_CompanyView>();
            Mapper.Map<Customer_Company, Customer_CompanyView>(input, this);

            this.created = input.created.ToString().Replace('T', ' ');
            this.updated = input.updated.ToString().Replace('T', ' ');
        }

        public Customer_Company convert(EntityFrameworkContext context)
        {
            var output = new Customer_Company();

            Mapper.CreateMap<Customer_PrivateView, Customer_Private>();
            Mapper.Map<Customer_CompanyView, Customer_Company>(this, output);

            return output;
        }
    }
}