using MvcKissApplication.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcKissApplication.Api.ViewModels
{
    public class SubsubcategoryController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public SubsubcategoryController()
            : this(new EntityFrameworkRepository())
        {

        }

        public SubsubcategoryController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        [HttpGet]
        [ActionName("DefaultAction")]
        public IEnumerable<SubsubcategoryView> Get()
        {
            var models = repo.getAllSubsubcategories();
            var views = SubsubcategoryView.getViews(models);
            return views;
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getSubsubcategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new SubsubcategoryView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        public HttpResponseMessage Employees(int id)
        {
            var model = repo.getSubsubcategory(id);
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
        public HttpResponseMessage Missions(int id)
        {
            var model = repo.getSubsubcategory(id);
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
        [ActionName("DefaultAction")]
        public HttpResponseMessage Subcategory(int id)
        {
            var model = repo.getSubsubcategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var subCategories = model.subcategory;
                var view = new SubcategoryView(subCategories);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(SubsubcategoryView view)
        {
            var model = view.getModel();
            model = repo.createSubsubcategory(model);
            view = new SubsubcategoryView(model);

            var response = Request.CreateResponse<SubsubcategoryView>(HttpStatusCode.Created, view);
            string uri = Url.Route(null, new { id = view.id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        [HttpPut]
        [ActionName("DefaultAction")]
        public void Put(int id, SubsubcategoryView view)
        {
            view.id = id;
            var model = view.getModel();
            repo.update(model);
        }
    }
}
