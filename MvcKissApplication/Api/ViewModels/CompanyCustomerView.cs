using AutoMapper;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Api.ViewModels
{
    public class CompanyCustomerView : CustomerView
    {

        #region VARIABLES

        public string organisationNumber { get; set; }

        public string companyName { get; set; }

        public string type { get { return "CompanyCustomer"; } }

        #endregion

        public CompanyCustomerView()
        {

        }

        public CompanyCustomerView(CompanyCustomer model)
        {
            Mapper.CreateMap<CompanyCustomer, CompanyCustomerView>();
            Mapper.Map<CompanyCustomer, CompanyCustomerView>(model, this);
            
            this.created = model.created.ToString().Replace('T', ' ');
            this.updated = model.updated.ToString().Replace('T', ' ');
        }

        public CompanyCustomer getModel()
        {
            var model = new CompanyCustomer();

            Mapper.CreateMap<CompanyCustomerView, CompanyCustomer>();
            Mapper.Map<CompanyCustomerView, CompanyCustomer>(this, model);
            
            return model;
        }

        public static IEnumerable<CompanyCustomerView> getViews(IEnumerable<CompanyCustomer> models)
        {
            Mapper.CreateMap<CompanyCustomer, CompanyCustomerView>();
            var views = Mapper.Map<IEnumerable<CompanyCustomer>, IEnumerable<CompanyCustomerView>>(models);
            
            return views;
        }

    }
}