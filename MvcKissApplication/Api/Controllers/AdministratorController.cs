using MvcKissApplication.Api.Helpers;
using MvcKissApplication.Api.ViewModels;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.OutputCache;

namespace MvcKissApplication.Api.controllers
{
    public class AdministratorController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public AdministratorController()
            : this(new EntityFrameworkRepository())
        {

        }

        public AdministratorController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        // GET api/administrator
        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IEnumerable<AdministratorView> Get()
        {
            var models = repo.getAllAdministrators();
            var views = AdministratorView.getViews(models);
            return views;
        }

        // GET api/administrator/5
        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getAdministrator(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new AdministratorView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetLogin(string email, string password)
        {
            var model = repo.getAdministrator(email, password);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new AdministratorView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        // POST api/administrator
        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(AdministratorView view)
        {
            var model = view.getModel();
            model.created = DateTime.UtcNow;
            model.updated = DateTime.UtcNow;
            model.fakeId = Guid.NewGuid();
            model = repo.createAdministrator(model);
            view = new AdministratorView(model);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, view);
            response.Headers.Location = new Uri(Url.Link("ApiControllerAndId", new { id = view.id }));
            return response;
        }

        // PUT api/administrator/5
        [HttpPut]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Put(int id, AdministratorView view)
        {
            if (id != view.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
            var model = view.getModel();
            model.updated = DateTime.UtcNow;

            try
            {
                repo.update(model);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/admin/5
        [HttpDelete]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Remove(int id)
        {
            var model = repo.getAdministrator(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                try 
                {
                    repo.deleteAdministrator(id);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
        }

        protected override void Dispose(bool disposing)
        {
            repo.dispose();
            base.Dispose(disposing);
        }
    }
}
