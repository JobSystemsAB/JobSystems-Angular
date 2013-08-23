using AutoMapper;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Api.ViewModels
{
    public class SubsubcategoryView
    {

        #region VARIABLES

        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        #endregion

        public SubsubcategoryView()
        {

        }

        public SubsubcategoryView(Subsubcategory model)
        {
            Mapper.CreateMap<Subsubcategory, SubsubcategoryView>();
            Mapper.Map<Subsubcategory, SubsubcategoryView>(model, this);
        }

        public Subsubcategory getModel()
        {
            var model = new Subsubcategory();

            Mapper.CreateMap<SubsubcategoryView, Subsubcategory>();
            Mapper.Map<SubsubcategoryView, Subsubcategory>(this, model);
        
            return model;
        }

        public static IEnumerable<SubsubcategoryView> getViews(IEnumerable<Subsubcategory> models)
        {
            Mapper.CreateMap<Subsubcategory, SubsubcategoryView>();
            var views = Mapper.Map<IEnumerable<Subsubcategory>, IEnumerable<SubsubcategoryView>>(models);
        
            return views;
        }

    }
}