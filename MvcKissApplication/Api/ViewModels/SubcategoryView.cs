using AutoMapper;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Api.ViewModels
{
    public class SubcategoryView
    {

        #region VARIABLES

        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        #endregion

        public SubcategoryView()
        {

        }

        public SubcategoryView(Subcategory model)
        {
            Mapper.CreateMap<Subcategory, SubcategoryView>();
            Mapper.Map<Subcategory, SubcategoryView>(model, this);
        }

        public Subcategory getModel()
        {
            var model = new Subcategory();

            Mapper.CreateMap<SubcategoryView, Subcategory>();
            Mapper.Map<SubcategoryView, Subcategory>(this, model);
            
            return model;
        }

        public static IEnumerable<SubcategoryView> getViews(IEnumerable<Subcategory> models)
        {
            Mapper.CreateMap<Subcategory, SubcategoryView>();
            var views = Mapper.Map<IEnumerable<Subcategory>, IEnumerable<SubcategoryView>>(models);
            
            return views;
        }

    }
}