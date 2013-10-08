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
    //[Authorize]
    public class MissionController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public MissionController()
            : this(new EntityFrameworkRepository())
        {

        }

        public MissionController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IQueryable<MissionView> Get()
        {
            var models = repo.getAllMissions().Where(m => m.enabled);
            var views = MissionView.getViews(models);
            return views.AsQueryable();
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IQueryable<MissionView> All()
        {
            var models = repo.getAllMissions();
            var views = MissionView.getViews(models);
            return views.AsQueryable();
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IQueryable<MissionView> Disabled()
        {
            var models = repo.getAllMissions().Where(m => !m.enabled);
            var views = MissionView.getViews(models);
            return views.AsQueryable();
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IQueryable<MissionView> Employed()
        {
            var models = repo.getAllMissions().Where(m => m.employee != null && m.enabled);
            var views = MissionView.getViews(models);
            return views.AsQueryable();
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IQueryable<MissionView> Unemployed()
        {
            var models = repo.getAllMissions().Where(m => m.employee == null && m.enabled);
            var views = MissionView.getViews(models);
            return views.AsQueryable();
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getMission(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new MissionView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Customer(int id)
        {
            var model = repo.getMission(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var customer = model.customer;
                var view = new CustomerView(customer);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]        
        public HttpResponseMessage Employee(int id)
        {
            var model = repo.getMission(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var employee = model.employee;
                var view = new EmployeeView(employee);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage WorkShift(int id)
        {
            var model = repo.getMission(id);
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

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(MissionView view)
        {
            var model = view.getModel(repo);
            model.created = DateTime.UtcNow;
            model.updated = DateTime.UtcNow;
            model.enabled = true;
            model.fakeId = Guid.NewGuid();
            model = repo.createMission(model);
            view = new MissionView(model);

            var response = Request.CreateResponse<MissionView>(HttpStatusCode.Created, view);
            string uri = Url.Route(null, new { id = view.id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        public class connectCategoriesInput 
        {
            public int missionId { get; set; }
            public int[] categoryIds { get; set; }
            public connectCategoriesInput () {}
        }

        [HttpPost]
        public HttpResponseMessage ConnectCategories(connectCategoriesInput input)
        {
            var mission = repo.getMission(input.missionId);
            var categories = repo.getCategories(input.categoryIds);
            if (mission == null || categories.Count() < 1)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                mission.categories = categories.ToArray();
                repo.update(mission);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpPost]
        public HttpResponseMessage ConnectCustomer(dynamic input)
        {
            var mission = repo.getMission((int)input.missionId.Value);
            var customer = repo.getCustomer((int)input.customerId.Value);
            if (mission == null || customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                mission.customer = customer;
                repo.update(mission);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpPost]
        public HttpResponseMessage ConnectEmployee(dynamic input)
        {
            var mission = repo.getMission((int)input.missionId.Value);
            var employee = repo.getEmployee((int)input.employeeId.Value);
            if (mission == null || employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                mission.employee = employee;
                repo.update(mission);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
        [HttpPut]
        [ActionName("DefaultAction")]
        public void Put(int id, MissionView view)
        {
            view.id = id;
            var model = view.getModel(repo);
            model.updated = DateTime.UtcNow;
            repo.update(model);
        }

    }
}
