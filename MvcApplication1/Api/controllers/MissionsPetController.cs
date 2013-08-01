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
    public class MissionsPetController : ApiController
    {
        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public MissionsPetController()
        {
            this._context = new EntityFrameworkContext();
        }

        public MissionsPetController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        #region DEFAULTS

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Create(MissionPetView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    view.created = DateTime.UtcNow.ToString();
                    view.enabled = true;

                    var original = view.convert(this._context);
                    this._context.petMissions.Add(original);
                    this._context.SaveChanges();
                    view.id = original.id;

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

        #endregion

    }
}
