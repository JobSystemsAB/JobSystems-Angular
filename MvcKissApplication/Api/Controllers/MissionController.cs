using MvcKissApplication.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcKissApplication.Api.ViewModels
{
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
        public IEnumerable<MissionView> Get()
        {
            var models = repo.getAllMissions();
            var views = MissionView.getViews(models);
            return views;
        }

        [HttpGet]
        [ActionName("DefaultAction")]
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

        [HttpGet]
        public int Amount()
        {
            return repo.getAllMissions().Count();
        }

        [HttpGet]
        public int EnabledAmount()
        {
            return repo.getAllMissions().Where(m => m.enabled).Count();
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(MissionView view)
        {
            var model = view.getModel();
            model.created = DateTime.UtcNow;
            model.updated = DateTime.UtcNow;
            model = repo.createMission(model);
            view = new MissionView(model);

            var response = Request.CreateResponse<MissionView>(HttpStatusCode.Created, view);
            string uri = Url.Route(null, new { id = view.id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        [HttpPost]
        public HttpResponseMessage ConnectCategory(dynamic input)
        {
            var mission = repo.getMission((int)input.missionId.Value);
            var category = repo.getCategory((int)input.categoryId.Value);
            if (mission == null || category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                mission.category = category;
                repo.update(mission);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpPost]
        public HttpResponseMessage ConnectSubcategory(dynamic input)
        {
            var mission = repo.getMission((int)input.missionId.Value);
            var subcategory = repo.getSubcategory((int)input.subcategoryId.Value);
            if (mission == null || subcategory == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                mission.subcategory = subcategory;
                mission.category = subcategory.category;
                repo.update(mission);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpPost]
        public HttpResponseMessage ConnectSubsubcategory(dynamic input)
        {
            var mission = repo.getMission((int)input.missionId.Value);
            var subsubcategory = repo.getSubsubcategory((int)input.subsubcategoryId.Value);
            if (mission == null || subsubcategory == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                mission.subsubcategory = subsubcategory;
                mission.subcategory = subsubcategory.subcategory;
                mission.category = subsubcategory.subcategory.category;
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
            var model = view.getModel();
            model.updated = DateTime.UtcNow;
            repo.update(model);
        }

    }
}
