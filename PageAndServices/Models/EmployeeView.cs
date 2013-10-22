using AutoMapper;
using PageAndServices.Helpers;
using PageAndServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    public class EmployeeView
    {

        #region VARIABLES

        public int id { get; set; }

        public int[] categoryIds { get; set; }

        public string description { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string emailAddress { get; set; }

        public string phoneNumber { get; set; }

        public string personalNumber { get; set; }

        public string bankName { get; set; }

        public string bankClearingNumber { get; set; }

        public string bankAccountNumber { get; set; }

        public string password { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

        public Address address { get; set; }

        public bool enabled { get; set; }

        #endregion

        public EmployeeView()
        {

        }

        public EmployeeView(Employee model)
        {
            Mapper.CreateMap<Employee, EmployeeView>();
            Mapper.Map<Employee, EmployeeView>(model, this);
            
            this.created = model.created.ToString().Replace('T', ' ');
            this.updated = model.updated.ToString().Replace('T', ' ');
            this.categoryIds = model.categories.Select(c => c.id).ToArray();
        }

        public Employee getModel(IRepository repo)
        {
            var model = new Employee();

            Mapper.CreateMap<EmployeeView, Employee>();
            Mapper.Map<EmployeeView, Employee>(this, model);

            if (this.categoryIds.Length > 0) { model.categories = repo.getCategories(this.categoryIds).ToArray(); }

            return model;
        }

        public static IEnumerable<EmployeeView> getViews(IEnumerable<Employee> models)
        {
            Mapper.CreateMap<Employee, EmployeeView>();
            var views = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeView>>(models);
            
            return views;
        }
    }
}