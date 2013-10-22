using AutoMapper;
using PageAndServices.Helpers;
using PageAndServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    public class MissionView
    {

        #region VARIABLES

        public int id { get; set; }

        public int? hours { get; set; }

        public int? customerId { get; set; }

        public int[] categoryIds { get; set; }

        public string description { get; set; }

        public string date { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

        public string extras { get; set; }

        public Address address { get; set; }

        public bool enabled { get; set; }


        #endregion

        public MissionView()
        {

        }

        public MissionView(Mission model)
        {
            Mapper.CreateMap<Mission, MissionView>();
            Mapper.Map<Mission, MissionView>(model, this);
            
            this.created = model.created.ToString().Replace('T', ' ');
            this.updated = model.updated.ToString().Replace('T', ' ');
            this.date = model.date == null ? String.Empty : model.date.ToString();
            this.categoryIds = model.categories.Select(c => c.id).ToArray();
        }

        public Mission getModel(IRepository repo)
        {
            var model = new Mission();

            Mapper.CreateMap<MissionView, Mission>();
            Mapper.Map<MissionView, Mission>(this, model);

            if (this.customerId != null) { model.customer = repo.getCustomer((int)this.customerId); }
            if (this.categoryIds.Length > 0) { model.categories = repo.getCategories(this.categoryIds).ToArray(); }

            return model;
        }

        public static IEnumerable<MissionView> getViews(IEnumerable<Mission> models)
        {
            Mapper.CreateMap<Mission, MissionView>();
            var views = Mapper.Map<IEnumerable<Mission>, IEnumerable<MissionView>>(models);
            
            return views;
        }
    }
}