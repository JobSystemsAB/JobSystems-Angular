using PageAndServices.Models;
using PageAndServices.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.OutputCache;

namespace PageAndServices.Controllers
{
    public class TestimonialController : ApiController
    {
        #region CONSTRUCTORS

        private IRepository repo;

        public TestimonialController()
            : this(new EntityFrameworkRepository())
        {

        }

        public TestimonialController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        // GET api/testimonail
        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IEnumerable<Testimonial> Get()
        {
            var models = repo.getAllTestimonials();
            return models;
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IEnumerable<Testimonial> GetLanguage(string language)
        {
            var models = repo.getTestimonials(language);
            return models;
        }

        // GET api/testimonial/5
        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getTestimonial(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
        }

        // POST api/text
        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(Testimonial model)
        {
            model.created = DateTime.UtcNow;
            model = repo.createTestimonial(model);
            
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            response.Headers.Location = new Uri(Url.Link("ApiControllerAndId", new { id = model.id }));
            return response;
        }

        // POST api/text/SaveTexts
        [HttpPost]
        public HttpResponseMessage SaveTestimonials(IEnumerable<Testimonial> models)
        {
            foreach (var model in models)
            {
                var original = repo.getText(model.id);
                if (original.text != model.text)
                {
                    model.enabled = true;
                    model.created = DateTime.UtcNow;
                    repo.createTestimonial(model);

                    original.enabled = false;
                    repo.update(original);
                }
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT api/text/5
        [HttpPut]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Put(Testimonial model)
        {
            try
            {
                repo.update(model);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/text/5
        [HttpDelete]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Remove(int id)
        {
            var model = repo.getTestimonial(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                try 
                {
                    repo.deleteTestimonial(id);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
        }

        protected override void Dispose(bool disposing)
        {
            repo.dispose();
            base.Dispose(disposing);
        }
    }
}
