using AutoMapper;
using MvcWebRole.Database.Helper;
using MvcWebRole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole.Api.Models
{
    public class KnowledgeView
    {
        public int id { get; set; }

        public int categoryId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public KnowledgeView()
        {
        }

        public KnowledgeView(Knowledge input)
        {
            Mapper.CreateMap<Knowledge, KnowledgeView>();
            Mapper.Map<Knowledge, KnowledgeView>(input, this);
        }

        public Knowledge convert(EntityFrameworkContext context)
        {
            var output = new Knowledge();

            Mapper.CreateMap<KnowledgeView, Knowledge>();
            Mapper.Map<KnowledgeView, Knowledge>(this, output);

            return output;
        }
    }
}