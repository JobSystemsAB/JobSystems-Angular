using CryptSharp;
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
    public class PerformerController : ApiController
    {

        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public PerformerController()
        {
            this._context = new EntityFrameworkContext();
        }

        public PerformerController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        #region DEFAULTS

        [HttpGet]
        [ActionName("DefaultAction")]
        public IQueryable<PerformerView> GetAll()
        {
            var result = new List<PerformerView>();
            foreach (var performer in this._context.performers)
            {
                result.Add(new PerformerView(performer));
            }

            return result.AsQueryable();
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        public PerformerView Get(int id)
        {
            var performer = this._context.performers.FirstOrDefault(c => c.id == id);
            if (performer == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new PerformerView(performer);
        }

        [HttpGet]
        public IQueryable<AssignmentView> Assigments(int id)
        {
            var performer = this._context.performers.FirstOrDefault(c => c.id == id);
            if (performer == null)
            {
                return null;
            }

            var result = new List<AssignmentView>();
            foreach (var assignment in performer.assignments)
            {
                result.Add(new AssignmentView(assignment));
            }
            return result.AsQueryable();
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Create(PerformerView view)
        {
            if (this._context.performers.Any(p => p.emailAddress == view.emailAddress))
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Email already in use");
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    if (!String.IsNullOrWhiteSpace(view.newPassword))
                    {
                        view.password = Crypter.Blowfish.Crypt(view.password);
                    }

                    var original = view.convert(this._context);
                    original.created = DateTime.UtcNow;
                    this._context.performers.Add(original);
                    this._context.SaveChanges();
                    view = new PerformerView(original);

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
        public HttpResponseMessage Update(PerformerView view)
        {
            if (!String.IsNullOrWhiteSpace(view.emailAddress) &&
                this._context.performers.Any(p => p.emailAddress == view.emailAddress && p.id != view.id))
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Email already in use");
            }
            else if (ModelState.IsValid)
            {
                try
                {

                    if (!String.IsNullOrWhiteSpace(view.newPassword))
                    {
                        view.password = Crypter.Blowfish.Crypt(view.newPassword);
                    }

                    var original = this._context.performers.FirstOrDefault(p => p.id == view.id);
                    original.updated = DateTime.UtcNow;
                    AutoMapper.Mapper.CreateMap<Performer, Performer>();
                    AutoMapper.Mapper.Map<Performer, Performer>(view.convert(this._context), original);
                    this._context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
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
            var performer = this._context.performers.FirstOrDefault(p => p.id == id);
            if (performer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this._context.performers.Remove(performer);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, performer);
        }

        #endregion DEFAULTS

        //[HttpPatch]
        //public HttpResponseMessage PatchPerformer(int id, Delta<PerformerView> attributes)
        //{
        //    var original = this._context.performers.FirstOrDefault(p => p.id == id);
        //    if (original == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    try
        //    {
        //        var performerView = new PerformerView(original);
        //        performerView.updated = DateTime.UtcNow;
        //        attributes.Patch(performerView);
        //        AutoMapper.Mapper.CreateMap<Performer, Performer>();
        //        AutoMapper.Mapper.Map<Performer, Performer>(performerView.convert(this._context), original);
        //        this._context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, original);
        //}

        [HttpGet]
        public int Login(string emailAddress, string password)
        {
            var performer = this._context.performers.FirstOrDefault(p => p.emailAddress == emailAddress);

            if (performer == null)
                return 0;
            else
                return CryptSharp.Crypter.CheckPassword(password, performer.password) ? performer.id : 0;
        }

        //[HttpGet]
        //public IQueryable<AssignmentView> GetAssignments(int pid)
        //{
        //    var performer = this._context.performers.FirstOrDefault(c => c.id == pid);
        //    if (performer == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    var result = new List<AssignmentView>();
        //    foreach (var assignment in performer.assignments)
        //    {
        //        result.Add(new AssignmentView(assignment));
        //    }

        //    return result.AsQueryable();
        //}
    }
}
