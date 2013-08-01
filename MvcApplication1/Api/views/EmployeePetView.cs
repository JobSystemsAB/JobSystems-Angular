using AutoMapper;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class EmployeePetView : EmployeeView
    {

        public int employeeId { get; set; }

        public int[] petIds { get; set; }

        public bool approved { get; set; }



        // -- CONSTRUCTOR --

        public EmployeePetView()
        {
        }

        public EmployeePetView(EmployeePet input)
        {
            Mapper.CreateMap<EmployeePet, EmployeePetView>();
            Mapper.Map<EmployeePet, EmployeePetView>(input, this);

            Mapper.CreateMap<Employee, EmployeePetView>();
            Mapper.Map<Employee, EmployeePetView>(input.employee, this);

            this.created = input.created.ToString().Replace('T', ' ');
            this.updated = input.employee.updated.ToString().Replace('T', ' ');

            this.petIds = input.pets.Select(e => e.id).ToArray();
        }

        public EmployeePet convert(EntityFrameworkContext context)
        {
            var output = new EmployeePet();

            Mapper.CreateMap<EmployeePetView, EmployeePet>();
            Mapper.Map<EmployeePetView, EmployeePet>(this, output);

            var employee = new Employee();
            Mapper.CreateMap<EmployeePetView, Employee>();
            Mapper.Map<EmployeePetView, Employee>(this, employee);
            output.employee = employee;

            if (this.petIds != null)
                foreach (var pet in context.pets.Where(p => this.petIds.Contains(p.id)))
                    output.pets.Add(pet);

            return output;
        }
    }
}