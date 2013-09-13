using AutoMapper;
using MvcKissApplication.Database.Helpers;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Api.ViewModels
{
    public class EmployeeView
    {

        #region VARIABLES

        public int id { get; set; }

        public int categoryId { get; set; }

        public int[] subcategoryIds { get; set; }

        public int[] subsubcategoryIds { get; set; }

        public string infoText { get; set; }

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
        }

        public Employee getModel()
        {
            var model = new Employee();

            Mapper.CreateMap<EmployeeView, Employee>();
            Mapper.Map<EmployeeView, Employee>(this, model);
            
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