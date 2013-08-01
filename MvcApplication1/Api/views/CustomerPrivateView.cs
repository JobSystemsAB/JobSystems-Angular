using AutoMapper;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class CustomerPrivateView
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

        public CustomerPrivateView()
        {
        }

        public CustomerPrivateView(CustomerPrivate input)
        {
            Mapper.CreateMap<CustomerPrivate, CustomerPrivateView>();
            Mapper.Map<CustomerPrivate, CustomerPrivateView>(input, this);

            this.created = input.created.ToString().Replace('T', ' ');
            this.updated = input.updated.ToString().Replace('T', ' ');
        }

        public CustomerPrivate convert(EntityFrameworkContext context)
        {
            var output = new CustomerPrivate();

            Mapper.CreateMap<CustomerPrivateView, CustomerPrivate>();
            Mapper.Map<CustomerPrivateView, CustomerPrivate>(this, output);

            return output;
        }
    }
}