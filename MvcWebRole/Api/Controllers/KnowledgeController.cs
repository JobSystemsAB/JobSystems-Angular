using MvcWebRole.Api.Models;
using MvcWebRole.Database.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWebRole.Api.Controllers
{
    public class KnowledgeController : ApiController
    {
        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public KnowledgeController()
        {
            this._context = new EntityFrameworkContext();
        }

        public KnowledgeController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        [HttpGet]
        public IQueryable<KnowledgeView> Category(int categoryId)
        {
            var knowledges = this._context.knowledges.Where(k => k.categoryId == categoryId);

            var result = new List<KnowledgeView>();
            foreach (var knowledge in knowledges)
            {
                result.Add(new KnowledgeView(knowledge));
            }

            return result.AsQueryable();
        }
    }
}
