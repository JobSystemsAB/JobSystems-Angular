using EasyHttp.Http;
using PageAndServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PageAndServices.Helpers
{
    public class ElkTextMessage : ITextMessage
    {
        public static EasyHttp.Http.HttpResponse send(TextMessageView view)
        {
            var deliveredUrl = "http://www.adoer.se/api/sms/deliveredelk";
            var responseUrl = "http://www.adoer.se/api/sms/recieveelk";

            var apiUrl = "https://api.46elks.com/a1/SMS";

            var username = "u6d73bed464ac3ed22cee974d4ccff303";
            var password = "6EEADFB28D47D4C8B27FCAE7F7E58531";

            var data = String.Format("from={0}&to={1}&message={2}&whendelivered={3}$sms_url={4}",
                view.from, view.to, view.message, deliveredUrl, responseUrl);

            var http = new EasyHttp.Http.HttpClient();
            http.Request.SetBasicAuthentication(username, password);

            return http.Post(apiUrl, data, HttpContentTypes.ApplicationXWwwFormUrlEncoded);
        }
    }
}