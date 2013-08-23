using AutoMapper;
using MvcKissApplication.Database.Helpers;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Api.ViewModels
{
    public class MissionView
    {

        #region VARIABLES

        public int id { get; set; }

        public string description { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

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
        }

        public Mission getModel()
        {
            var model = new Mission();

            Mapper.CreateMap<MissionView, Mission>();
            Mapper.Map<MissionView, Mission>(this, model);
            
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