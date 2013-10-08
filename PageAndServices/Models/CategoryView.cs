using AutoMapper;
using PageAndServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    public class CategoryView
    {

        #region VARIABLES

        public int id { get; set; }

        public int salary { get; set; }

        public int order { get; set; }

        public int? parentId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string url { get; set; }

        #endregion

        public CategoryView()
        {

        }

        public CategoryView(Category model)
        {
            Mapper.CreateMap<Category, CategoryView>();
            Mapper.Map<Category, CategoryView>(model, this);
            this.parentId = model.parent == null ? null : (int?)model.parent.id;
        }

        public Category getModel(IRepository repo)
        {
            var model = new Category()
            {
                description = this.description,
                id = this.id,
                name = this.name,
                salary = this.salary,
                parent = this.parentId == null ? null : repo.getCategory((int)this.parentId),
                order = this.order,
                url = this.url
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
                            salary = model.salary,
                            order = model.order,
                            url = model.url
                        };

            return views;
        }

    }
}