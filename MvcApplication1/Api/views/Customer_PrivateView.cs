using AutoMapper;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class Customer_PrivateView
    {

        public int id { get; set; }

        public string emailAddress { get; set; }

        public string phoneNumber { get; set; }

        public string password { get; set; }

        public Address address { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

        public bool enabled { get; set; }



        public string firstName { get; set; }

        public string lastName { get; set; }

        public string personalNumber { get; set; }

        public string propertyName { get; set; }



        // -- CONSTRUCTOR --

        public Customer_PrivateView()
        {
        }

        public Customer_PrivateView(Customer_Private input)
        {
            Mapper.CreateMap<Customer_Private, Customer_PrivateView>();
            Mapper.Map<Customer_Private, Customer_PrivateView>(input, this);

            this.created = input.created.ToString().Replace('T', ' ');
            this.updated = input.updated.ToString().Replace('T', ' ');
        }

        public Customer_Private convert(EntityFrameworkContext context)
        {
            var output = new Customer_Private();

            Mapper.CreateMap<Customer_PrivateView, Customer_Private>();
            Mapper.Map<Customer_PrivateView, Customer_Private>(this, output);

            return output;
        }
    }
}