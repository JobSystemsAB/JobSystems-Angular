using MvcKissApplication.Api.Helpers;
using MvcKissApplication.Api.ViewModels;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        [HttpGet]
        [ActionName("DefaultAction")]
        public IEnumerable<AdministratorView> Get()
        {
            var models = repo.getAllAdministrators();
            var views = AdministratorView.getViews(models);
            return views;
        }

        [HttpGet]
        [ActionName("DefaultAction")]
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

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(AdministratorView view)
        {
            var model = view.getModel();
            model.created = DateTime.UtcNow;
            model.updated = DateTime.UtcNow;
            model = repo.createAdministrator(model);
            view = new AdministratorView(model);

            var response = Request.CreateResponse<AdministratorView>(HttpStatusCode.Created, view);
            string uri = Url.Route(null, new { id = view.id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        [HttpPut]
        [ActionName("DefaultAction")]
        public void Put(int id, AdministratorView view)
        {
            view.id = id;
            var model = view.getModel();
            model.updated = DateTime.UtcNow;
            repo.update(model);
        }

        [HttpDelete]
        [ActionName("DefaultAction")]
        public void Remove(int id)
        {
            repo.deleteAdministrator(id);
        }

    }
}
