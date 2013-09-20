using EasyHttp.Http;
using MvcKissApplication.Api.Helpers;
using MvcKissApplication.Api.ViewModels;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcKissApplication.Api.Controllers
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
            var deliveredUrl = "http://www.adoer.se/api/sms/delivered";
            var responseUrl = "http://www.adoer.se/api/sms/recieve";
            var apiUrl = "https://api.46elks.com/a1/SMS";

            var username = "u6d73bed464ac3ed22cee974d4ccff303";
            var password = "6EEADFB28D47D4C8B27FCAE7F7E58531";

            var data = String.Format("from={0}&to={1}&message={2}&whendelivered={3}$sms_url={4}", 
                view.from, view.to, view.message, deliveredUrl, responseUrl);

            var http = new EasyHttp.Http.HttpClient();
            http.Request.SetBasicAuthentication(username, password);

            var ans = http.Post(apiUrl, data, HttpContentTypes.ApplicationXWwwFormUrlEncoded);

            var model = view.getModel();
            model.created = DateTime.UtcNow;

            if (ans.StatusCode == HttpStatusCode.OK)
            {
                var body = ans.DynamicBody;

                model.apiId = body.id;
                model.error = false;

                model = repo.createTextMessage(model);

                return Request.CreateResponse(ans.StatusCode, model);
            }
            else
            {
                var message = ans.RawText.Replace("\"", String.Empty);
                
                model.error = true;
                model.errorMessage = message;
                model = repo.createTextMessage(model);

                return Request.CreateResponse(ans.StatusCode, message);
            }

        }

        [HttpPost]
        public HttpResponseMessage Recieve(TextMessageView view)
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
        public HttpResponseMessage Delivered(elkDeliveryReport view)
        {
            var model = repo.getTextMessage(view.id);

            model = repo.createTextMessage(model);

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

    }
}
