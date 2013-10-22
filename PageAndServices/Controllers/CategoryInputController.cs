using PageAndServices.Models;
using PageAndServices.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.OutputCache;

namespace PageAndServices.Controllers
{
    public class CategoryInputController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public CategoryInputController()
            : this(new EntityFrameworkRepository())
        {

        }

        public CategoryInputController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IEnumerable<CategoryInputView> Get()
        {
            var models = repo.getAllCategoryInputs();
            var views = CategoryInputView.getViews(models);
            return views;
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getCategoryInput(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new CategoryInputView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(CategoryInputView view)
        {
            var model = view.getModel(repo);
            model = repo.createCategoryInput(model);
            view = new CategoryInputView(model);

            var response = Request.CreateResponse<CategoryInputView>(HttpStatusCode.Created, view);
            string uri = Url.Route(null, new { id = view.id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        [HttpPut]
        [ActionName("DefaultAction")]
        public void Put(CategoryInputView view)
        {
            var model = view.getModel(repo);
            repo.update(model);
        }

        [HttpDelete]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Delete(int id)
        {
            var model = repo.getCategoryInput(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                try
                {
                    repo.deleteCategoryInput(id);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
        }
    }
}
