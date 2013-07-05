using AutoMapper;
using MvcWebRole.Database.Helper;
using MvcWebRole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole.Api.Models
{
    public class PerformerTimeFreeView
    {
        public int id { get; set; }

        public int performerId { get; set; }

        public DateTime day { get; set; }

        public bool morning { get; set; }

        public bool afternoon { get; set; }

        public bool evening { get; set; }


        public PerformerTimeFreeView()
        {
        }

        public PerformerTimeFreeView(PerformerTimeFree input)
        {
            Mapper.CreateMap<PerformerTimeFree, PerformerTimeFreeView>();
            Mapper.Map<PerformerTimeFree, PerformerTimeFreeView>(input, this);
        }

        public PerformerTimeFree convert(EntityFrameworkContext context)
        {
            var output = new PerformerTimeFree();

            Mapper.CreateMap<PerformerTimeFreeView, PerformerTimeFree>();
            Mapper.Map<PerformerTimeFreeView, PerformerTimeFree>(this, output);

            return output;
        }
    }
}