using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class PetView
    {
        public int id { get; set; }

        public string name { get; set; }

        public int[] employeeIds { get; set; }

        public int[] missionIds { get; set; }


        public PetView()
        {
        }

        public PetView(Pet input)
        {
            AutoMapper.Mapper.CreateMap<Pet, PetView>();
            AutoMapper.Mapper.Map<Pet, PetView>(input, this);

            //this.employeeIds = input.employees.Select(e => e.id).ToArray();
            //this.missionIds = input.missions.Select(m => m.id).ToArray();
        }

        public Pet convert(EntityFrameworkContext context)
        {
            var output = new Pet();

            AutoMapper.Mapper.CreateMap<PetView, Pet>();
            AutoMapper.Mapper.Map<PetView, Pet>(this, output);

            //if (this.employeeIds != null)
            //    foreach (var employee in context.pet_employees.Where(e => this.employeeIds.Contains(e.id)))
            //        output.employees.Add(employee);

            //if (this.missionIds != null)
            //    foreach (var mission in context.pet_missions.Where(m => this.missionIds.Contains(m.id)))
            //        output.missions.Add(mission);
            
            return output;
        }
    }
}