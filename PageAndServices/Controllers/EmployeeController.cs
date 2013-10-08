using PageAndServices.Models;
using PageAndServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.OutputCache;

namespace PageAndServices.Controllers
{
    public class EmployeeController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public EmployeeController()
            : this(new EntityFrameworkRepository())
        {

        }

        public EmployeeController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IEnumerable<EmployeeView> Get()
        {
            var models = repo.getAllEmployees();
            var views = EmployeeView.getViews(models);
            return views;
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getEmployee(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new EmployeeView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetLogin(string email, string password)
        {
            var model = repo.getEmployee(email, password);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new EmployeeView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Missions(int id)
        {
            var model = repo.getEmployee(id);
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
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage WorkShifts(int id)
        {
            var model = repo.getEmployee(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var workShifts = model.workShifts;
                var views = WorkShiftView.getViews(workShifts);
                return Request.CreateResponse(HttpStatusCode.OK, views);

            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public int Amount()
        {
            return repo.getAllEmployees().Count();
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(EmployeeView view)
        {
            var model = view.getModel();
            model.created = DateTime.UtcNow;
            model.updated = DateTime.UtcNow;
            model.fakeId = Guid.NewGuid();
            model = repo.createEmployee(model);
            view = new EmployeeView(model);

            var response = Request.CreateResponse<EmployeeView>(HttpStatusCode.Created, view);
            string uri = Url.Route(null, new { id = view.id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        [HttpPost]
        public HttpResponseMessage ConnectCategory(dynamic input)
        {
            var employee = repo.getEmployee((int)input.employeeId.Value);

            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var categoryIds = new int[input.categoryIds.Count];
                for (int i = 0; i < input.categoryIds.Count; i++ )
                {
                    categoryIds[i] = (int)input.categoryIds[i];
                }
                
                var categories = repo.getCategories(categoryIds);
                employee.categories = categories.ToArray();
                
                repo.update(employee);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpPut]
        [ActionName("DefaultAction")]
        public void Put(int id, EmployeeView view)
        {
            view.id = id;
            var model = view.getModel();
            model.updated = DateTime.UtcNow;
            repo.update(model);
        }
    }
}
