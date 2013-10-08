using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    public class TextView
    {
        #region VARIABLES

        public int id { get; set; }

        public string controllerName { get; set; }

        public string elementId { get; set; }

        public string language { get; set; }

        public string text { get; set; }

        public string created { get; set; }

        public bool enabled { get; set; }

        #endregion

        public TextView()
        {

        }

        public TextView(Text model)
        {
            Mapper.CreateMap<Text, TextView>();
            Mapper.Map<Text, TextView>(model, this);
        }

        public Text getModel()
        {
            var model = new Text();

            Mapper.CreateMap<TextView, Text>();
            Mapper.Map<TextView, Text>(this, model);

            return model;
        }

        public static IEnumerable<TextView> getViews(IEnumerable<Text> models)
        {
            Mapper.CreateMap<Text, TextView>();
            var views = Mapper.Map<IEnumerable<Text>, IEnumerable<TextView>>(models);

            return views;
        }
    }
}