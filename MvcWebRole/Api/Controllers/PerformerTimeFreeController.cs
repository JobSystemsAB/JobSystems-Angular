using MvcWebRole.Api.Models;
using MvcWebRole.Database.Helper;
using MvcWebRole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWebRole.Api.Controllers.Helper
{
    public class PerformerTimeFreeController : ApiController
    {
        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public PerformerTimeFreeController()
        {
            this._context = new EntityFrameworkContext();
        }

        public PerformerTimeFreeController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        #region DEFAULT

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Create(PerformerTimeFreeView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var original = view.convert(this._context);
                    original.changed = DateTime.UtcNow;
                    this._context.performerTimesFree.Add(original);
                    this._context.SaveChanges();
                    view = new PerformerTimeFreeView(original);

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
        public HttpResponseMessage Update(PerformerTimeFreeView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var original = this._context.performerTimesFree.FirstOrDefault(a => a.id == view.id);
                    original.changed = DateTime.UtcNow;
                    AutoMapper.Mapper.CreateMap<PerformerTimeFree, PerformerTimeFree>();
                    AutoMapper.Mapper.Map<PerformerTimeFree, PerformerTimeFree>(view.convert(this._context), original);
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

        #endregion

        [HttpGet]
        public HttpResponseMessage Exists(DateTime date, int performerId)
        {
            try
            {
                var found = this._context.performerTimesFree.Any(ptf => ptf.day == date && ptf.performerId == performerId);
                return Request.CreateResponse(HttpStatusCode.OK, found);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        public HttpResponseMessage PerformerMonth(int performerId, int month, int year)
        {
            try
            {
                var performer = this._context.performers.FirstOrDefault(p => p.id == performerId);
                var dates = performer.freeTimes.Where(ptf => ptf.day.Month == month && ptf.day.Year == year);

                var result = new List<PerformerTimeFreeView>();
                foreach (var date in dates)
                {
                    result.Add(new PerformerTimeFreeView(date));
                }

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            } 
        }

    }
}
