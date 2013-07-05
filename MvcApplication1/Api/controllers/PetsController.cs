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
    public class PetsController : ApiController
    {
        
        #region CONSTRUCTOR

        private EntityFrameworkContext _context;

        public PetsController()
        {
            this._context = new EntityFrameworkContext();
        }

        public PetsController(EntityFrameworkContext context)
        {
            this._context = context;
        }

        #endregion CONSTRUCTOR

        #region DEFAULTS

        [HttpGet]
        [ActionName("DefaultAction")]
        public IQueryable<PetView> GetAll()
        {
            var result = new List<PetView>();
            foreach (var pet in this._context.pets)
            {
                result.Add(new PetView(pet));
            }

            return result.AsQueryable();
        }

        #endregion
    }
}
