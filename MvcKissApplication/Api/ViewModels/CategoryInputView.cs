using AutoMapper;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Api.ViewModels
{
    public class CategoryInputView
    {

        #region VARIABLES

        public int id { get; set; }

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
        }

        public CategoryInput getModel()
        {
            var model = new CategoryInput();

            Mapper.CreateMap<CategoryInputView, CategoryInput>();
            Mapper.Map<CategoryInputView, CategoryInput>(this, model);
 
            return model;
        }

        public static IEnumerable<CategoryInputView> getViews(IEnumerable<CategoryInput> models)
        {
            Mapper.CreateMap<CategoryInput, CategoryInputView>();
            var views = Mapper.Map<IEnumerable<CategoryInput>, IEnumerable<CategoryInputView>>(models);

            return views;
        }
    }
}