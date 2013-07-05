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
    public class CustomerMissionsController : ApiController
    {

        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public CustomerMissionsController()
        {
            this._context = new EntityFrameworkContext();
        }

        public CustomerMissionsController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        [HttpPost]
        public HttpResponseMessage CreatePet(CustomerMission_PetView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var original = view.convert(this._context);
                    original.created = DateTime.UtcNow;
                    original.enabled = true;
                    this._context.pet_missions.Add(original);
                    this._context.SaveChanges();
                    view = new CustomerMission_PetView(original);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, view);
                    return response;
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

    }
}
