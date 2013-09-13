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
    public class TextController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public TextController()
            : this(new EntityFrameworkRepository())
        {

        }

        public TextController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        // GET api/text
        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IEnumerable<TextView> Get()
        {
            var models = repo.getAllTexts();
            var views = TextView.getViews(models);
            return views;
        }

        // GET api/text/5
        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getText(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new TextView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage GetPageText(string controllerName, string language)
        {
            var models = repo.getText(controllerName, language);
            if (models.Count() < 1)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var views = TextView.getViews(models);
                return Request.CreateResponse(HttpStatusCode.OK, views);
            }
        }

        // POST api/text
        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(TextView view)
        {
            var model = view.getModel();
            model.created = DateTime.UtcNow;
            model.updated = DateTime.UtcNow;
            model = repo.createText(model);
            view = new TextView(model);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, view);
            response.Headers.Location = new Uri(Url.Link("ApiControllerAndId", new { id = view.id }));
            return response;
        }

        // PUT api/text/5
        [HttpPut]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Put(int id, TextView view)
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

        // DELETE api/text/5
        [HttpDelete]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Remove(int id)
        {
            var model = repo.getText(id);
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
