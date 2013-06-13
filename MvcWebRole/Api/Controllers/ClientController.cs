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
    public class ClientController : ApiController
    {

        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public ClientController()
        {
            this._context = new EntityFrameworkContext();
        }

        public ClientController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        #region DEFAULTS

        [HttpGet]
        [ActionName("DefaultAction")]
        public IQueryable<ClientView> GetAll()
        {
            var result = new List<ClientView>();
            foreach (var client in this._context.clients)
            {
                result.Add(new ClientView(client));
            }

            return result.AsQueryable();
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        public ClientView Get(int id)
        {
            var client = this._context.clients.FirstOrDefault(c => c.id == id);
            if (client == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new ClientView(client);
        }

        [HttpGet]
        public IQueryable<AssignmentView> Assigments(int clientId)
        {
            var result = new List<AssignmentView>();
            foreach (var assignment in this._context.clients.FirstOrDefault(c => c.id == clientId).assignments)
            {
                result.Add(new AssignmentView(assignment));
            }
            return result.AsQueryable();
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        public IQueryable<AssignmentView> GetAssignments(int id)
        {
            var client = this._context.clients.FirstOrDefault(c => c.id == id);
            if (client == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            var result = new List<AssignmentView>();
            foreach (var assignment in client.assignments)
            {
                result.Add(new AssignmentView(assignment));
            }

            return result.AsQueryable();
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Create(ClientView view)
        {
            if (this._context.clients.Any(c => c.organisationNumber == view.organisationNumber))
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Organisationnumber in use");
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    var original = view.convert(this._context);
                    original.created = DateTime.UtcNow;
                    this._context.clients.Add(original);
                    this._context.SaveChanges();
                    view = new ClientView(original);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, view);
                    //response.Headers.Location = new Uri(Url.Link("Default", new { id = performer.performerID }));
                    return response;
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Update(ClientView client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var original = this._context.clients.FirstOrDefault(c => c.id == client.id);
                    original.updated = DateTime.UtcNow;
                    AutoMapper.Mapper.CreateMap<Client, Client>();
                    AutoMapper.Mapper.Map<Client, Client>(client.convert(this._context), original);
                    this._context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, client);
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
            var original = this._context.clients.FirstOrDefault(c => c.id == id);
            if (original == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this._context.clients.Remove(original);
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
        //public HttpResponseMessage Patch(int id, Delta<ClientView> attributes)
        //{
        //    var original = this._context.clients.FirstOrDefault(c => c.id == id);
        //    if (original == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    try
        //    {
        //        var clientView = new ClientView(original);
        //        clientView.updated = DateTime.UtcNow;
        //        attributes.Patch(clientView);
        //        AutoMapper.Mapper.CreateMap<Client, Client>();
        //        AutoMapper.Mapper.Map<Client, Client>(clientView.convert(this._context), original);
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
