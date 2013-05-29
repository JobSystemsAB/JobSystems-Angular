using CryptSharp;
using MvcWebRole.Api.Controllers.Helper;
using MvcWebRole.Api.Models;
using MvcWebRole.Database.Helper;
using MvcWebRole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWebRole.Api.Controllers
{
    public class AdministratorController : ApiController
    {

        #region CONSTRUCTORS

        private EntityFrameworkContext _context;

        public AdministratorController()
        {
            this._context = new EntityFrameworkContext();
        }

        public AdministratorController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTORS

        #region DEFAULTS

        [HttpGet]
        //[RequireHttps]
        [ActionName("DefaultAction")]
        public IQueryable<AdministratorView> GetAll()
        {
            //RequireAdministratorLogin.Authenticate(accessToken);

            var result = new List<AdministratorView>();
            foreach (var administrator in this._context.administrators)
            {
                result.Add(new AdministratorView(administrator));
            }
            return result.AsQueryable();
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        public AdministratorView Get(int id)
        {
            var original = this._context.administrators.FirstOrDefault(a => a.id == id);
            if (original == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new AdministratorView(original);
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Create(AdministratorView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!String.IsNullOrWhiteSpace(view.newPassword))
                    {
                        view.password = Crypter.Blowfish.Crypt(view.newPassword);
                    }

                    var original = view.convert(this._context);
                    original.created = DateTime.UtcNow;
                    this._context.administrators.Add(original);
                    this._context.SaveChanges();
                    view = new AdministratorView(original);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, view);
                    //response.Headers.Location = new Uri(Url.Link("Default", new { id = performer.performerID }));
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

        [HttpPut]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Update(AdministratorView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var original = this._context.administrators.FirstOrDefault(a => a.id == view.id);

                    if (!String.IsNullOrWhiteSpace(view.newPassword))
                    {
                        view.password = Crypter.Blowfish.Crypt(view.newPassword);
                    }
                    
                    AutoMapper.Mapper.CreateMap<Administrator, Administrator>();
                    AutoMapper.Mapper.Map<Administrator, Administrator>(view.convert(this._context), original);
                    this._context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, view);
                //response.Headers.Location = new Uri(Url.Link("Default", new { id = performer.performerID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Delete(int id)
        {
            var original = this._context.administrators.FirstOrDefault(a => a.id == id);
            if (original == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this._context.administrators.Remove(original);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, original);
        }

        #endregion DEFAULTS

        [HttpPost]
        public HttpResponseMessage Login(AdministratorView view)
        {
            var original = this._context.administrators.FirstOrDefault(p => p.username == view.username);

            if (original == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (CryptSharp.Crypter.CheckPassword(view.password, original.password))
            {
                return Request.CreateResponse(HttpStatusCode.OK, original);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }


        //[HttpPatch]
        //public HttpResponseMessage Patch(int id, Delta<AdministratorView> attributes)
        //{
        //    var original = this._context.administrators.FirstOrDefault(c => c.id == id);
        //    if (original == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    try
        //    {
        //        var view = new AdministratorView(original);
        //        attributes.Patch(view);
        //        AutoMapper.Mapper.CreateMap<Administrator, Administrator>();
        //        AutoMapper.Mapper.Map<Administrator, Administrator>(view.convert(this._context), original);
        //        this._context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, original);
        //}
    }
}
