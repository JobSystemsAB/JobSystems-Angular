using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    public class AdministratorView
    {

        #region VARIABLES

        public int id { get; set; }

        public string password { get; set; }

        public string emailAddress { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

        public string authToken { get; set; }

        public bool enabled { get; set; }

        #endregion

        public AdministratorView()
        {

        }

        public AdministratorView(Administrator model)
        {
            Mapper.CreateMap<Administrator, AdministratorView>();
            Mapper.Map<Administrator, AdministratorView>(model, this);
            
            this.created = model.created.ToString().Replace('T', ' ');
            this.updated = model.updated.ToString().Replace('T', ' ');
        }

        public Administrator getModel()
        {
            var model = new Administrator();

            Mapper.CreateMap<AdministratorView, Administrator>();
            Mapper.Map<AdministratorView, Administrator>(this, model);
            
            return model;
        }

        public static IEnumerable<AdministratorView> getViews(IEnumerable<Administrator> models)
        {
            Mapper.CreateMap<Administrator, AdministratorView>();
            var views = Mapper.Map<IEnumerable<Administrator>, IEnumerable<AdministratorView>>(models);
            
            return views;
        }

    }
}