using AutoMapper;
using MvcApplication1.Database.Helpers;
using MvcApplication1.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Api.views
{
    public class AdministratorView
    {

        public int id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string newPassword { get; set; }

        public string emailAddress { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

        public bool enabled { get; set; }



        // -- CONSTRUCTOR --

        public AdministratorView()
        {
        }

        public AdministratorView(Administrator input)
        {
            Mapper.CreateMap<Administrator, AdministratorView>();
            Mapper.Map<Administrator, AdministratorView>(input, this);

            this.created = input.created.ToString().Replace('T', ' ');
            this.updated = input.updated.ToString().Replace('T', ' ');
        }

        public Administrator convert(EntityFrameworkContext context)
        {
            var output = new Administrator();

            Mapper.CreateMap<AdministratorView, Administrator>();
            Mapper.Map<AdministratorView, Administrator>(this, output);

            return output;
        }
    }
}