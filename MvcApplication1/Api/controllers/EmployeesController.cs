using MvcApplication1.Api.views;
using MvcApplication1.Database.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Api.controllers
{
    public class EmployeesController : ApiController
    {

        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public EmployeesController()
        {
            this._context = new EntityFrameworkContext();
        }

        public EmployeesController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        #region DEFAULTS

        [HttpGet]
        [ActionName("DefaultAction")]
        public IQueryable<EmployeeView> GetAll()
        {
            var result = new List<EmployeeView>();
            foreach (var employee in this._context.employees)
            {
                result.Add(new EmployeeView(employee));
            }

            return result.AsQueryable();
        }

        #endregion

        [HttpPost]
        public HttpResponseMessage Login(EmployeeView view)
        {
            var original = this._context.employees.FirstOrDefault(e => e.emailAddress == view.emailAddress);

            if (original == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else if (view.password == original.password)
            {
                return Request.CreateResponse(HttpStatusCode.OK, original);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}
