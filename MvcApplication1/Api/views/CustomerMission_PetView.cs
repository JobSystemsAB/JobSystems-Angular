using AutoMapper;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class CustomerMission_PetView
    {

        public int id { get; set; }

        public string description { get; set; }

        public string created { get; set; }
        
        public Address address { get; set; }

        public bool enabled { get; set; }



        public bool cat { get; set; }

        public bool dog { get; set; }

        public string other { get; set; }

        public string startDateAndTime { get; set; }

        public int duration { get; set; }




         // -- CONSTRUCTOR --

        public CustomerMission_PetView()
        {
        }

        public CustomerMission_PetView(CustomerMission_Pet input)
        {
            Mapper.CreateMap<CustomerMission_Pet, CustomerMission_PetView>();
            Mapper.Map<CustomerMission_Pet, CustomerMission_PetView>(input, this);

            this.created = input.created.ToString().Replace('T', ' ');
            this.startDateAndTime = input.startDateAndTime.ToString().Replace('T', ' ');
        }

        public CustomerMission_Pet convert(EntityFrameworkContext context)
        {
            var output = new CustomerMission_Pet();

            Mapper.CreateMap<CustomerMission_PetView, CustomerMission_Pet>();
            Mapper.Map<CustomerMission_PetView, CustomerMission_Pet>(this, output);

            return output;
        }
    }
}