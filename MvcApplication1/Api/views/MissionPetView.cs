using AutoMapper;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class MissionPetView : MissionView
    {
        public int petId { get; set; }

        public string startDate { get; set; }

        public string startTime { get; set; }

        public int duration { get; set; }




         // -- CONSTRUCTOR --

        public MissionPetView()
        {
        }

        public MissionPetView(MissionPet input)
        {
            Mapper.CreateMap<MissionPet, MissionPetView>();
            Mapper.Map<MissionPet, MissionPetView>(input, this);

            this.created = input.created.ToString().Replace('T', ' ');
            this.startDate = input.startDate.ToString().Replace('T', ' ');
            this.startTime = input.startTime.ToString().Replace('T', ' ');
            this.petId = input.pet.id;
        }

        public MissionPet convert(EntityFrameworkContext context)
        {
            var output = new MissionPet();

            Mapper.CreateMap<MissionPetView, MissionPet>();
            Mapper.Map<MissionPetView, MissionPet>(this, output);

            output.pet = context.pets.FirstOrDefault(p => p.id == this.petId);
            output.employee = this.employeeId == null ? null : context.employees.FirstOrDefault(e => e.id == this.employeeId);
            output.customer = this.customerId == null ? null : context.customers.FirstOrDefault(c => c.id == this.customerId);

            return output;
        }
    }
}