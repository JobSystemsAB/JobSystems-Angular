using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PageAndServices.Models
{
    public class TextMessageView
    {
        #region VARIABLES

        public string message { get; set; }

        public string from { get; set; }
        
        public string to { get; set; }

        #endregion

        public TextMessageView()
        {

        }

        public TextMessageView(TextMessage model)
        {
            Mapper.CreateMap<TextMessage, TextMessageView>();
            Mapper.Map<TextMessage, TextMessageView>(model, this);
        }

        public TextMessage getModel()
        {
            var model = new TextMessage();

            Mapper.CreateMap<TextMessageView, TextMessage>();
            Mapper.Map<TextMessageView, TextMessage>(this, model);

            return model;
        }

        public static IEnumerable<TextMessageView> getViews(IEnumerable<TextMessage> models)
        {
            Mapper.CreateMap<TextMessage, TextMessageView>();
            var views = Mapper.Map<IEnumerable<TextMessage>, IEnumerable<TextMessageView>>(models);

            return views;
        }
    }
}