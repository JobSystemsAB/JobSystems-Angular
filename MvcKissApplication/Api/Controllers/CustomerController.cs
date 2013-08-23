using MvcKissApplication.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcKissApplication.Api.ViewModels
{
    public class CustomerController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public CustomerController()
            : this(new EntityFrameworkRepository())
        {

        }

        public CustomerController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        [HttpGet]
        [ActionName("DefaultAction")]
        public IEnumerable<CustomerView> Get()
        {
            var models = repo.getAllCustomers();
            var views = CustomerView.getViews(models);
            return views;
        }

        [HttpGet]
        public HttpResponseMessage GetLogin(string email, string password)
        {
            var model = repo.getCustomer(email, password);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new CustomerView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        public HttpResponseMessage Mission(int id)
        {
            var model = repo.getCustomer(id);
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
        public int Amount(int id)
        {
            return repo.getAllCompanyCustomers().Count();
        }
    }
}
