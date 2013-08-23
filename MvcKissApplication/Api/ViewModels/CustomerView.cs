using AutoMapper;
using MvcKissApplication.Database.Helpers;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Api.ViewModels
{
    public class CustomerView
    {

        #region VARIABLES

        public int id { get; set; }

        public string emailAddress { get; set; }

        public string phoneNumber { get; set; }

        public string password { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

        public string type { get; set; }

        public bool enabled { get; set; }

        #endregion

        public CustomerView()
        {

        }

        public CustomerView(Customer model)
        {
            Mapper.CreateMap<Customer, CustomerView>();
            Mapper.Map<Customer, CustomerView>(model, this);
            
            this.created = model.created.ToString().Replace('T', ' ');
            this.updated = model.updated.ToString().Replace('T', ' ');
            this.type = model.GetType().BaseType.Name;
        }

        public Customer getModel()
        {
            var model = new Customer();

            Mapper.CreateMap<CustomerView, Customer>();
            Mapper.Map<CustomerView, Customer>(this, model);
            
            return model;
        }

        public static IEnumerable<CustomerView> getViews(IEnumerable<Customer> models)
        {
            var views = from model in models
                        select new CustomerView
                        {
                            created = model.created.ToString(),
                            emailAddress = model.emailAddress,
                            enabled = model.enabled,
                            id = model.id,
                            password = model.password,
                            phoneNumber = model.phoneNumber,
                            updated = model.updated.ToString(),
                            type = model.GetType().BaseType.Name
                        };

            return views;
        }
    }
}