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
    public class AssignmentController : ApiController
    {

        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public AssignmentController()
        {
            this._context = new EntityFrameworkContext();
        }

        public AssignmentController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        #region DEFAULTS
        
        [HttpGet]
        [ActionName("DefaultAction")]
        public IQueryable<AssignmentView> GetAll()
        {
            var result = new List<AssignmentView>();
            foreach (var assignment in this._context.assignments)
            {
                result.Add(new AssignmentView(assignment));
            }
            return result.AsQueryable();
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        public AssignmentView Get(int id)
        {
            var original = this._context.assignments.FirstOrDefault(a => a.id == id);
            if (original == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new AssignmentView(original);
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Create(AssignmentView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var original = view.convert(this._context);
                    original.created = DateTime.UtcNow;
                    this._context.assignments.Add(original);
                    this._context.SaveChanges();
                    view = new AssignmentView(original);

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

        [HttpPut]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Update(AssignmentView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var original = this._context.assignments.FirstOrDefault(a => a.id == view.id);
                    original.updated = DateTime.UtcNow;
                    AutoMapper.Mapper.CreateMap<Assignment, Assignment>();
                    AutoMapper.Mapper.Map<Assignment, Assignment>(view.convert(this._context), original);
                    this._context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, view);
                //response.Headers.Location = new Uri(Url.Link("Default", new { id = performer.performerID }));
                return response;
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
            var original = this._context.assignments.FirstOrDefault(a => a.id == id);
            if (original == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this._context.assignments.Remove(original);
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
        //public HttpResponseMessage PatchAssignment(int id, Delta<AssignmentView> attributes)
        //{
        //    var original = this._context.assignments.FirstOrDefault(c => c.id == id);
        //    if (original == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    try
        //    {
        //        var assignmentView = new AssignmentView(original);
        //        assignmentView.updated = DateTime.UtcNow;
        //        attributes.Patch(assignmentView);
        //        AutoMapper.Mapper.CreateMap<Assignment, Assignment>();
        //        AutoMapper.Mapper.Map<Assignment, Assignment>(assignmentView.convert(this._context), original);
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
