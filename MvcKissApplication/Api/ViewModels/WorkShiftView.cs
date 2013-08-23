using AutoMapper;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Api.ViewModels
{
    public class WorkShiftView
    {

        #region VARIABLES

        public int id { get; set; }

        public string date { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

        public TimeSpan span { get; set; }

        #endregion

        public WorkShiftView()
        {

        }

        public WorkShiftView(WorkShift model)
        {
            Mapper.CreateMap<WorkShift, WorkShiftView>();
            Mapper.Map<WorkShift, WorkShiftView>(model, this);
            
            this.created = model.created.ToString().Replace('T', ' ');
            this.updated = model.updated.ToString().Replace('T', ' ');
        }

        public WorkShift getModel()
        {
            var model = new WorkShift();

            Mapper.CreateMap<WorkShiftView, WorkShift>();
            Mapper.Map<WorkShiftView, WorkShift>(this, model);
            
            return model;
        }

        public static IEnumerable<WorkShiftView> getViews(IEnumerable<WorkShift> models)
        {
            Mapper.CreateMap<WorkShift, WorkShiftView>();
            var views = Mapper.Map<IEnumerable<WorkShift>, IEnumerable<WorkShiftView>>(models);
            
            return views;
        }

    }
}