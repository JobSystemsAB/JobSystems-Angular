using MvcApplication1.Api.views;
using MvcApplication1.Database.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Api.controllers
{
    public class CustomersCompanyController : ApiController
    {
        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public CustomersCompanyController()
        {
            this._context = new EntityFrameworkContext();
        }

        public CustomersCompanyController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        #region DEFAULTS

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Create(CustomerCompanyView view)
        {
            if (ModelState.IsValid)
            {
                var customer = this._context.companyCustomers.FirstOrDefault(c => c.organisationNumber == view.organisationNumber);

                if (customer == null)
                {
                    try
                    {
                        view.created = DateTime.UtcNow.ToString();
                        view.updated = DateTime.UtcNow.ToString();
                        view.enabled = true;

                        var original = view.convert(this._context);
                        this._context.companyCustomers.Add(original);
                        this._context.SaveChanges();

                        view.id = original.id;
                            
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

        #endregion

    }

}
