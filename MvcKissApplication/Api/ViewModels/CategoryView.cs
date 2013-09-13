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

        public int? parentId { get; set; }

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
            this.parentId = model.parent.id;
        }

        public Category getModel()
        {
            var model = new Category()
            {
                description = this.description,
                id = this.id,
                name = this.name,
                salary = this.salary
            };

            return model;
        }

        public static IEnumerable<CategoryView> getViews(IEnumerable<Category> models)
        {
            var views = from model in models
                        select new CategoryView()
                        {
                            description = model.description,
                            id = model.id,
                            name = model.name,
                            parentId = model.parent == null ? null : (int?) model.parent.id,
                            salary = model.salary
                        };

            return views;
        }

    }
}