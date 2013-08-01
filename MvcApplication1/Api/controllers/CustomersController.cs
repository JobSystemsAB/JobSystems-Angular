using MvcApplication1.Api.views;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Api.controllers
{
    public class CustomersController : ApiController
    {

        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public CustomersController()
        {
            this._context = new EntityFrameworkContext();
        }

        public CustomersController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion

        [HttpPost]
        public HttpResponseMessage Login(CustomerView view)
        {
            var original = this._context.customers.FirstOrDefault(p => p.emailAddress == view.emailAddress);

            if (original == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else if (view.password == original.password)
            {
                if (original.GetType().BaseType == typeof(CustomerPrivate))
                {
                    var temp = (CustomerPrivate)original;
                    var data = new CustomerPrivateView(temp);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    var temp = (CustomerCompany)original;
                    var data = new CustomerCompanyView(temp);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}
