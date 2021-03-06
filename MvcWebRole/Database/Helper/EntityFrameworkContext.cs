﻿using MvcWebRole.Api.Models;
using MvcWebRole.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcWebRole.Database.Helper
{
    public class EntityFrameworkContext : DbContext
    {
        public DbSet<Performer> performers { get; set; }
        public DbSet<PerformerAccessToken> performerAccessToken { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Assignment> assignments { get; set; }
        public DbSet<PerformerTimeReport> performerTimeReports { get; set; }
        public DbSet<PerformerTimeFree> performerTimesFree { get; set; }
        public DbSet<Administrator> administrators { get; set; }
        public DbSet<AdministratorAccessToken> administratorAccessTokens { get; set; }
        public DbSet<Knowledge> knowledges { get; set; }
        public DbSet<KnowledgeCategory> knowledgeCategories { get; set; }
    }
}