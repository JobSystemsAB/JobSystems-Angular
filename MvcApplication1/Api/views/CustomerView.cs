using AutoMapper;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class CustomerView
    {

        public int id { get; set; }

        public string emailAddress { get; set; }

        public string phoneNumber { get; set; }

        public string password { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

        public Address address { get; set; }

        public bool enabled { get; set; }



         // -- CONSTRUCTOR --

        public CustomerView()
        {
        }

        public CustomerView(Customer input)
        {
            Mapper.CreateMap<Customer, CustomerView>();
            Mapper.Map<Customer, CustomerView>(input, this);

            this.created = input.created.ToString().Replace('T', ' ');
            this.updated = input.updated.ToString().Replace('T', ' ');
        }

        public Customer convert(EntityFrameworkContext context)
        {
            var output = new Customer();

            Mapper.CreateMap<CustomerView, Customer>();
            Mapper.Map<CustomerView, Customer>(this, output);

            return output;
        }
    }
}