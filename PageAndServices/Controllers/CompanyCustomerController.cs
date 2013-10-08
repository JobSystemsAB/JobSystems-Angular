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
    public class CompanyCustomerController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public CompanyCustomerController()
            : this(new EntityFrameworkRepository())
        {

        }

        public CompanyCustomerController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IEnumerable<CompanyCustomerView> Get()
        {
            var models = repo.getAllCompanyCustomers();
            var views = CompanyCustomerView.getViews(models);
            return views;
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getCompanyCustomer(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new CompanyCustomerView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public int Amount()
        {
            return repo.getAllCompanyCustomers().Count();
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(CompanyCustomerView view)
        {
            var model = view.getModel();
            model.created = DateTime.UtcNow;
            model.updated = DateTime.UtcNow;
            model.enabled = true;
            model.fakeId = Guid.NewGuid();
            model = repo.createCompanyCustomer(model);
            view = new CompanyCustomerView(model);

            var response = Request.CreateResponse<CompanyCustomerView>(HttpStatusCode.Created, view);
            string uri = Url.Route(null, new { id = view.id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        [HttpPut]
        [ActionName("DefaultAction")]
        public void Put(int id, CompanyCustomerView view)
        {
            view.id = id;
            var model = view.getModel();
            model.updated = DateTime.UtcNow;
            repo.update(model);
        }
    }
}
