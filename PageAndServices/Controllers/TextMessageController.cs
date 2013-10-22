using EasyHttp.Http;
using PageAndServices.Helpers;
using PageAndServices.Models;
using PageAndServices.Repository;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PageAndServices.Controllers
{
    public class TextMessageController : ApiController
    {
        #region CONSTRUCTORS

        private IRepository repo;

        public TextMessageController()
            : this(new EntityFrameworkRepository())
        {

        }

        public TextMessageController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        [HttpPost]
        public HttpResponseMessage PostElk(TextMessageView view)
        {

            var respons = ElkTextMessage.send(view);

            var model = view.getModel();
            model.created = DateTime.UtcNow;

            if (respons.StatusCode == HttpStatusCode.OK)
            {
                var body = respons.DynamicBody;

                model.apiId = body.id;
                model.error = false;

                model = repo.createTextMessage(model);

                return Request.CreateResponse(respons.StatusCode, model);
            }
            else
            {
                var message = respons.RawText.Replace("\"", String.Empty);
                
                model.error = true;
                model.errorMessage = message;
                model = repo.createTextMessage(model);

                return Request.CreateResponse(respons.StatusCode, message);
            }

        }

        [HttpPost]
        public HttpResponseMessage RecieveElk(TextMessageView view)
        {
            TextMessage model = new TextMessage
            {
                created = DateTime.UtcNow,
                from = view.from,
                to = view.to,
                message = view.message,
                error = false
            };

            model = repo.createTextMessage(model);

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        public class elkDeliveryReport 
        {
            public string id { get; set; }
            public string status { get; set; }
            public string delivered { get; set; }
        }

        [HttpPost]
        public HttpResponseMessage DeliveredElk(elkDeliveryReport view)
        {
            var model = repo.getTextMessage(view.id);

            model = repo.createTextMessage(model);

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

    }
}
