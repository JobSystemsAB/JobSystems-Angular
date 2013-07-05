using AutoMapper;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class Employee_PetView : EmployeeView
    {

        public int[] petIds { get; set; }

        public bool approved { get; set; }



        // -- CONSTRUCTOR --

        public Employee_PetView()
        {
        }

        public Employee_PetView(Employee_Pet input)
        {
            Mapper.CreateMap<Employee_Pet, Employee_PetView>();
            Mapper.Map<Employee_Pet, Employee_PetView>(input, this);

            this.created = input.created.ToString().Replace('T', ' ');
            this.updated = input.updated.ToString().Replace('T', ' ');

            this.petIds = input.pets.Select(e => e.id).ToArray();
        }

        public Employee_Pet convert(EntityFrameworkContext context)
        {
            var output = new Employee_Pet();

            Mapper.CreateMap<Employee_PetView, Employee_Pet>();
            Mapper.Map<Employee_PetView, Employee_Pet>(this, output);

            if (this.petIds != null)
                foreach (var pet in context.pets.Where(p => this.petIds.Contains(p.id)))
                    output.pets.Add(pet);

            return output;
        }
    }
}