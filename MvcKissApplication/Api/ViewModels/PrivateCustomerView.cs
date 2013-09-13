using AutoMapper;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Api.ViewModels
{
    public class PrivateCustomerView : CustomerView
    {

        #region VARIABLES

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string personalNumber { get; set; }

        public string propertyName { get; set; }

        public string type { get { return "PrivateCustomer"; } }

        public string extras { get; set; }

        #endregion

        public PrivateCustomerView()
        {

        }

        public PrivateCustomerView(PrivateCustomer model)
        {
            Mapper.CreateMap<PrivateCustomer, PrivateCustomerView>();
            Mapper.Map<PrivateCustomer, PrivateCustomerView>(model, this);
            
            this.created = model.created.ToString().Replace('T', ' ');
            this.updated = model.updated.ToString().Replace('T', ' ');
        }

        public PrivateCustomer getModel()
        {
            var model = new PrivateCustomer();

            Mapper.CreateMap<PrivateCustomerView, PrivateCustomer>().ForSourceMember(x => x.type, y => y.Ignore());
            Mapper.Map<PrivateCustomerView, PrivateCustomer>(this, model);
            
            return model;
        }

        public static IEnumerable<PrivateCustomerView> getViews(IEnumerable<PrivateCustomer> models)
        {
            Mapper.CreateMap<PrivateCustomer, PrivateCustomerView>();
            var views = Mapper.Map<IEnumerable<PrivateCustomer>, IEnumerable<PrivateCustomerView>>(models);
            
            return views;
        }
    }
}