using PageAndServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PageAndServices.Helpers
{
    public class EntityFrameworkContext : DbContext
    {
        public DbSet<Administrator> administrators { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<CategoryInput> categoryInputs { get; set; }
        public DbSet<CompanyCustomer> companyCustomers { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Mission> missions { get; set; }
        public DbSet<PrivateCustomer> privateCustomers { get; set; }
        public DbSet<Testimonial> testimonials { get; set; }
        public DbSet<Text> texts { get; set; }
        public DbSet<TextMessage> textMessages { get; set; }
        public DbSet<WorkShift> workShifts { get; set; }
    }
}