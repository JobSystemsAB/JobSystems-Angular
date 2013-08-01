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
    public class EmployeesPetController : ApiController
    {

        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public EmployeesPetController()
        {
            this._context = new EntityFrameworkContext();
        }

        public EmployeesPetController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        #region DEFAULTS

        [HttpGet]
        [ActionName("DefaultAction")]
        public IQueryable<EmployeePetView> GetAll()
        {
            var result = new List<EmployeePetView>();
            foreach (var employee in this._context.petEmployees)
            {
                result.Add(new EmployeePetView(employee));
            }

            return result.AsQueryable();
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Create(EmployeePetView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    view.isPet = true;
                    view.enabled = true;
                    view.approved = false;                    
                    view.created = DateTime.UtcNow.ToString();
                    view.updated = DateTime.UtcNow.ToString();

                    var original = view.convert(this._context);
                    this._context.petEmployees.Add(original);
                    this._context.SaveChanges();

                    view.id = original.id;

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, view);
                    //response.Headers.Location = new Uri(Url.Link("Default", new { id = performer.performerID }));
                    return response;
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }


        //[HttpPatch]
        //[ActionName("DefaultAction")]
        //public HttpResponseMessage Patch(int id, Delta<EmployeePetView> attributes)
        //{
        //    var original = this._context.petEmployees.FirstOrDefault(p => p.id == id);
        //    if (original == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    try
        //    {
        //        original.employee.updated = DateTime.UtcNow;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, original);
        //}

        #endregion

        [HttpPost]
        public HttpResponseMessage SendMissionRequest(MissionPetView view)
        {
            var petEmployees = from petEmployee in this._context.petEmployees
                               where petEmployee.employee.enabled &&
                                   petEmployee.approved == true &&
                                   petEmployee.pets.Any(p => p.id == view.petId)
                               select petEmployee;



            return null;
        }
    }
}
