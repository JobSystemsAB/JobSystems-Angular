using MvcKissApplication.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcKissApplication.Api.ViewModels
{
    public class SubcategoryController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public SubcategoryController()
            : this(new EntityFrameworkRepository())
        {

        }

        public SubcategoryController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        [HttpGet]
        [ActionName("DefaultAction")]
        public IEnumerable<SubcategoryView> Get()
        {
            var models = repo.getAllSubcategories();
            var views = SubcategoryView.getViews(models);
            return views;
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getSubcategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new SubcategoryView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        public HttpResponseMessage Missions(int id)
        {
            var model = repo.getSubcategory(id);
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
            var model = repo.getSubcategory(id);
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
        public HttpResponseMessage Category(int id)
        {
            var model = repo.getSubcategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var category = model.category;
                var view = new CategoryView(category);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        public HttpResponseMessage Subsubcategory(int id)
        {
            var model = repo.getSubcategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var subsubcategories = model.subsubcategories;
                var views = SubsubcategoryView.getViews(subsubcategories);
                return Request.CreateResponse(HttpStatusCode.OK, views);
            }
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(SubcategoryView view)
        {
            var model = view.getModel();
            model = repo.createSubcategory(model);
            view = new SubcategoryView(model);

            var response = Request.CreateResponse<SubcategoryView>(HttpStatusCode.Created, view);
            string uri = Url.Route(null, new { id = view.id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        [HttpPut]
        [ActionName("DefaultAction")]
        public void Put(int id, SubcategoryView view)
        {
            view.id = id;
            var model = view.getModel();
            repo.update(model);
        }
    }
}
