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
    public class PrivateCustomerController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public PrivateCustomerController()
            : this(new EntityFrameworkRepository())
        {

        }

        public PrivateCustomerController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IEnumerable<PrivateCustomerView> Get()
        {
            var models = repo.getAllPrivateCustomers();
            var views = PrivateCustomerView.getViews(models);
            return views;
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getPrivateCustomer(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new PrivateCustomerView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public int Amount()
        {
            return repo.getAllPrivateCustomers().Count();
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(PrivateCustomerView view)
        {
            var model = view.getModel();
            model.created = DateTime.UtcNow;
            model.updated = DateTime.UtcNow;
            model.enabled = true;
            model.fakeId = Guid.NewGuid();
            model = repo.createPrivateCustomer(model);
            view = new PrivateCustomerView(model);

            var response = Request.CreateResponse<PrivateCustomerView>(HttpStatusCode.Created, view);
            string uri = Url.Route(null, new { id = view.id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        [HttpPut]
        [ActionName("DefaultAction")]
        public void Put(int id, PrivateCustomerView view)
        {
            view.id = id;
            var model = view.getModel();
            model.updated = DateTime.UtcNow;
            repo.update(model);
        }
    }
}
