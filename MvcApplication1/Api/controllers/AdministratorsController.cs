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
    public class AdministratorsController : ApiController
    {

        #region CONSTRUCTORS

        private EntityFrameworkContext _context;

        public AdministratorsController()
        {
            this._context = new EntityFrameworkContext();
        }

        public AdministratorsController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTORS

        [HttpPost]
        public HttpResponseMessage Login(AdministratorView view)
        {
            var original = this._context.administrators.FirstOrDefault(p => p.username == view.username);

            if (original == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            //if (CryptSharp.Crypter.CheckPassword(view.password, original.password))
            //{
            //    return Request.CreateResponse(HttpStatusCode.OK, original);
            //}
            //else
            //{
                return Request.CreateResponse(HttpStatusCode.NotFound);
            //}
        }
    }
}
