using MvcKissApplication.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcKissApplication.Api.ViewModels
{
    public class CategoryController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public CategoryController()
            : this(new EntityFrameworkRepository())
        {

        }

        public CategoryController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        [HttpGet]
        [ActionName("DefaultAction")]
        public IEnumerable<CategoryView> Get()
        {
            var models = repo.getAllCategories();
            var views = CategoryView.getViews(models);
            return views;
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getCategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new CategoryView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        public HttpResponseMessage Missions(int id)
        {
            var model = repo.getCategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var missions = model.missions;
                var views = MissionView.getViews(missions);
                return Request.CreateResponse(HttpStatusCode.OK, views);
            }
        }

        [HttpGet]
        public HttpResponseMessage Employees(int id)
        {
            var model = repo.getCategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var employees = model.employees;
                var views = EmployeeView.getViews(employees);
                return Request.CreateResponse(HttpStatusCode.OK, views);
            }
        }

        [HttpGet]
        public HttpResponseMessage Subcategories(int id)
        {
            var model = repo.getCategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var subcategories = model.subcategories;
                var views = SubcategoryView.getViews(subcategories);
                return Request.CreateResponse(HttpStatusCode.OK, views);
            }
        }

        [HttpGet]
        public HttpResponseMessage CategoryInputs(int id)
        {
            var model = repo.getCategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var categoryInputs = model.categoryInputs;
                var views = CategoryInputView.getViews(categoryInputs);
                return Request.CreateResponse(HttpStatusCode.OK, views);
            }
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(CategoryView view)
        {
            var model = view.getModel();
            model = repo.createCategory(model);
            view = new CategoryView(model);

            var response = Request.CreateResponse<CategoryView>(HttpStatusCode.Created, view);
            string uri = Url.Route(null, new { id = view.id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        [HttpPut]
        [ActionName("DefaultAction")]
        public void Put(int id, CategoryView view)
        {
            view.id = id;
            var model = view.getModel();
            repo.update(model);
        }
    }
}
