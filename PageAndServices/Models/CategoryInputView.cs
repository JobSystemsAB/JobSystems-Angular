using AutoMapper;
using PageAndServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    public class CategoryInputView
    {

        #region VARIABLES

        public int id { get; set; }

        public int categoryId { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public string text { get; set; }

        #endregion

        public CategoryInputView()
        {

        }

        public CategoryInputView(CategoryInput model)
        {
            Mapper.CreateMap<CategoryInput, CategoryInputView>();
            Mapper.Map<CategoryInput, CategoryInputView>(model, this);
            
            this.categoryId = model.category.id;
        }

        public CategoryInput getModel(IRepository repo)
        {
            var model = new CategoryInput();

            Mapper.CreateMap<CategoryInputView, CategoryInput>();
            Mapper.Map<CategoryInputView, CategoryInput>(this, model);

            model.category = repo.getCategory(this.categoryId);

            return model;
        }

        public static IEnumerable<CategoryInputView> getViews(IEnumerable<CategoryInput> models)
        {
            Mapper.CreateMap<CategoryInput, CategoryInputView>();
            
            var views = from model in models
                        select new CategoryInputView
                        {
                            categoryId = model.category.id,
                            id = model.id,
                            name = model.name,
                            text = model.text,
                            type = model.type
                        };

            return views;
        }
    }
}