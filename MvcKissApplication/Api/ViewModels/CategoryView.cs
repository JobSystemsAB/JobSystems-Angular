using AutoMapper;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Api.ViewModels
{
    public class CategoryView
    {

        #region VARIABLES

        public int id { get; set; }

        public int salary { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        #endregion

        public CategoryView()
        {

        }

        public CategoryView(Category model)
        {
            Mapper.CreateMap<Category, CategoryView>();
            Mapper.Map<Category, CategoryView>(model, this);
        }

        public Category getModel()
        {
            var model = new Category();

            Mapper.CreateMap<CategoryView, Category>();
            Mapper.Map<CategoryView, Category>(this, model);
            
            return model;
        }

        public static IEnumerable<CategoryView> getViews(IEnumerable<Category> models)
        {
            Mapper.CreateMap<Category, CategoryView>();
            var views = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryView>>(models);

            return views;
        }

    }
}