using MvcKissApplication.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.OutputCache;

namespace MvcKissApplication.Api.ViewModels
{
    public class WorkShiftController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public WorkShiftController()
            : this(new EntityFrameworkRepository())
        {

        }

        public WorkShiftController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IEnumerable<WorkShiftView> Get()
        {
            var models = repo.getAllWorkShifts();
            var views = WorkShiftView.getViews(models);
            return views;
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getWorkShift(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new WorkShiftView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public double AmountMinutes()
        {
            return repo.getAllWorkShifts().Select(w => w.span.Minutes).Sum();
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(WorkShiftView view)
        {
            var model = view.getModel();
            model.created = DateTime.UtcNow;
            model.updated = DateTime.UtcNow;
            model = repo.createWorkShift(model);
            view = new WorkShiftView(model);

            var response = Request.CreateResponse<WorkShiftView>(HttpStatusCode.Created, view);
            string uri = Url.Route(null, new { id = view.id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        [HttpPut]
        [ActionName("DefaultAction")]
        public void Put(int id, WorkShiftView view)
        {
            view.id = id;
            var model = view.getModel();
            model.updated = DateTime.UtcNow;
            repo.update(model);
        }
    }
}
