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
        public HttpResponseMessage CreatePrivate(Customer_PrivateView view)
        {
            if (ModelState.IsValid)
            {
                var customer = this._context.private_customers.FirstOrDefault(c => c.personalNumber == view.personalNumber);

                if (customer == null)
                {
                    try
                    {
                        var original = view.convert(this._context);
                        original.created = DateTime.UtcNow;
                        original.enabled = true;
                        this._context.private_customers.Add(original);
                        this._context.SaveChanges();
                        view = new Customer_PrivateView(original);

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, view);
                        //response.Headers.Location = new Uri(Url.Link("Default", new { id = performer.performerID }));
                        return response;
                    }
                    catch (Exception ex)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                    }
                }
                else if (customer.emailAddress == view.emailAddress)
                {
                    // update customer

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, view);
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);                    
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

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
                if (original.GetType().BaseType == typeof(Customer_Private))
                {
                    var temp = (Customer_Private)original;
                    var data = new Customer_PrivateView(temp);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    var temp = (Customer_Company)original;
                    var data = new Customer_CompanyView(temp);
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
