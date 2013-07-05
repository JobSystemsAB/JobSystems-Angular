using MvcWebRole.Api.Models;
using MvcWebRole.Database.Helper;
using MvcWebRole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWebRole.Api.Controllers
{
    public class PerformerTimeReportController : ApiController
    {

        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public PerformerTimeReportController()
        {
            this._context = new EntityFrameworkContext();
        }

        public PerformerTimeReportController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        #region DEFAULTS

        [HttpGet]
        [ActionName("DefaultAction")]
        public IQueryable<PerformerTimeReportView> GetAll()
        {
            var result = new List<PerformerTimeReportView>();
            foreach (var assignmentTimeReport in this._context.performerTimeReports)
            {
                result.Add(new PerformerTimeReportView(assignmentTimeReport));
            }
            return result.AsQueryable();
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        public PerformerTimeReportView Get(int id)
        {
            var original = this._context.performerTimeReports.FirstOrDefault(a => a.id == id);
            if (original == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new PerformerTimeReportView(original);
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Create(PerformerTimeReportView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var original = view.convert(this._context);
                    original.created = DateTime.UtcNow;
                    this._context.performerTimeReports.Add(original);
                    this._context.SaveChanges();
                    view = new PerformerTimeReportView(original);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, view);
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

        [HttpPut]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Update(PerformerTimeReportView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var original = this._context.performerTimeReports.FirstOrDefault(a => a.id == view.id);
                    original.updated = DateTime.UtcNow;
                    AutoMapper.Mapper.CreateMap<PerformerTimeReport, PerformerTimeReport>();
                    AutoMapper.Mapper.Map<PerformerTimeReport, PerformerTimeReport>(view.convert(this._context), original);
                    this._context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Delete(int id)
        {
            var original = this._context.performerTimeReports.FirstOrDefault(a => a.id == id);
            if (original == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this._context.performerTimeReports.Remove(original);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, original);

        }

        #endregion DEFAULTS

        //[HttpPatch]
        //public HttpResponseMessage Patch(int id, Delta<AssignmentTimeReportView> attributes)
        //{
        //    var original = this._context.assignmentTimeReports.FirstOrDefault(c => c.id == id);
        //    if (original == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    try
        //    {
        //        var assignmentView = new AssignmentTimeReportView(original);
        //        assignmentView.updated = DateTime.UtcNow;
        //        attributes.Patch(assignmentView);
        //        AutoMapper.Mapper.CreateMap<AssignmentTimeReport, AssignmentTimeReport>();
        //        AutoMapper.Mapper.Map<AssignmentTimeReport, AssignmentTimeReport>(assignmentView.convert(this._context), original);
        //        this._context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, original);
        //}
    }
}
