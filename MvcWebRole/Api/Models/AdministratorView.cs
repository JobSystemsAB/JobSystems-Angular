using AutoMapper;
using MvcWebRole.Database.Helper;
using MvcWebRole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole.Api.Models
{
    public class AdministratorView 
    {
        public int id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string newPassword { get; set; }

        public string emailAddress { get; set; }

        public string created { get; set; }

        public bool enabled { get; set; }
        
        
        
        

        public AdministratorView()
        {
        }

        public AdministratorView(Administrator input)
        {
            Mapper.CreateMap<Administrator, AdministratorView>();
            Mapper.Map<Administrator, AdministratorView>(input, this);

            this.created = input.created.ToString().Replace('T', ' ');
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