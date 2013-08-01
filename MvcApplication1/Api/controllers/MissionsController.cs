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
    public class MissionsController : ApiController
    {

        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public MissionsController()
        {
            this._context = new EntityFrameworkContext();
        }

        public MissionsController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        [HttpPost]
        public HttpResponseMessage EmployMission(int missionId, int employeeId)
        {
            var mission = this._context.missions.FirstOrDefault(m => m.id == missionId);
            var employee = this._context.employees.FirstOrDefault(e => e.id == employeeId);

            if (mission != null && employee != null)
            {
                try
                {
                    mission.employee = employee;
                    this._context.SaveChanges();

                    var view = new MissionView(mission);

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

    }
}
