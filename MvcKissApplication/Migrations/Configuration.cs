namespace MvcKissApplication.Migrations
{
    using MvcKissApplication.Database.Helpers;
    using MvcKissApplication.Database.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcKissApplication.Database.Helpers.EntityFrameworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcKissApplication.Database.Helpers.EntityFrameworkContext context)
        {
            context.customers.AddOrUpdate
                (
                c => c.id,
                new Customer
                {
                    id = 1,
                    created = DateTime.UtcNow,
                    emailAddress = "misael@jobsystems.se",
                    enabled = true,
                    password = "misse",
                    phoneNumber = "0704333005",
                    updated = DateTime.UtcNow
                }
                );

            context.administrators.AddOrUpdate
                (
                a => a.id,
                new Administrator
                {
                    id = 1,
                    created = DateTime.UtcNow,
                    emailAddress = "admin@jobsystems.se",
                    enabled = true,
                    password = "admin",
                    updated = DateTime.UtcNow
                }
                );

            context.categories.AddOrUpdate
                (
                c => c.id,
                new Category
                {
                    id = 1,
                    description = "",
                    name = "Barnvakt m.m.",
                    salary = 130
                },
                new Category
                {
                    id = 2,
                    description = "",
                    name = "St�dning",
                    salary = 130
                },
                new Category
                {
                    id = 3,
                    description = "",
                    name = "Husdjurspassning",
                    salary = 130
                },
                new Category
                {
                    id = 4,
                    description = "",
                    name = "Tr�dg�rdsarbete",
                    salary = 130
                },
                new Category
                {
                    id = 5,
                    description = "",
                    name = "L�xhj�lp, heml�xor m.m.",
                    salary = 130
                },
                new Category
                {
                    id = 6,
                    description = "",
                    name = "�vrigt",
                    salary = 130
                },
                new Category 
                { 
                    id = 7,
                    description = "",
                    name = "Sn�skottning",
                    salary = 130
                }
                );

            context.categoryInputs.AddOrUpdate
                (
                c => c.id,
                new CategoryInput
                {
                    id = 1,
                    name = "numberChildren",
                    text = "Antal barn",
                    type = "number",
                    category = context.categories.FirstOrDefault(c => c.id == 1)
                },
                new CategoryInput
                {
                    id = 2,
                    name = "ageYoungestChild",
                    text = "Yngsta barnets �lder",
                    type = "number",
                    category = context.categories.FirstOrDefault(c => c.id == 1)
                },
                new CategoryInput
                {
                    id = 3,
                    name = "ageOldestChild",
                    text = "�ldsta barnets �lder",
                    type = "number",
                    category = context.categories.FirstOrDefault(c => c.id == 1)
                },
                new CategoryInput
                {
                    id = 4,
                    name = "numberSquaremeters",
                    text = "Antal kvadratmeter",
                    type = "number",
                    category = context.categories.FirstOrDefault(c => c.id == 2)
                },
                new CategoryInput
                {
                    id = 5,
                    name = "numberAnimals",
                    text = "Antal djur",
                    type = "number",
                    category = context.categories.FirstOrDefault(c => c.id == 3)
                },
                new CategoryInput
                {
                    id = 6,
                    name = "",
                    text = "Innefattar bortforsling",
                    type = "checkbox",
                    category = context.categories.FirstOrDefault(c => c.id == 4)
                },
                new CategoryInput
                {
                    id = 7,
                    name = "toolsAvailability",
                    text = "Verktyg finns",
                    type = "checkbox",
                    category = context.categories.FirstOrDefault(c => c.id == 4)
                },
                new CategoryInput 
                { 
                    id = 8,
                    name = "numberSquaremeters",
                    text = "Antal kvadratmeter",
                    type = "number",
                    category = context.categories.FirstOrDefault(c => c.id == 7)
                },
                new CategoryInput
                {
                    id = 9,
                    name = "snowthrowerAvailability",
                    text = "Sn�slunga finnes",
                    type = "checkbox",
                    category = context.categories.FirstOrDefault(c => c.id == 7)
                },
                new CategoryInput
                {
                    id = 10,
                    name = "snowskyffelAvailability",
                    text = "Sn�skyffel finnes",
                    type = "checkbox",
                    category = context.categories.FirstOrDefault(c => c.id == 7)
                }
                );

            context.subcategories.AddOrUpdate
                (
                s => s.id,
                new Subcategory 
                { 
                    id = 1,
                    name = "Barnvakt akut",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 1)
                },
                new Subcategory
                {
                    id = 2,
                    name = "Barnvakt kontinuerligt",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 1)
                },
                new Subcategory
                {
                    id = 3,
                    name = "Barnvakt enstaka tillf�llen",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 1)
                },
                new Subcategory
                {
                    id = 4,
                    name = "�vrigt",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 1)
                },
                new Subcategory
                {
                    id = 5,
                    name = "St�dning en g�ng",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 2)
                },
                new Subcategory
                {
                    id = 6,
                    name = "St�dning kontinuerligt",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 2)
                },
                new Subcategory
                {
                    id = 7,
                    name = "�vrigt",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 2)
                },
                new Subcategory
                {
                    id = 8,
                    name = "Hundpassning",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 3)
                },
                new Subcategory
                {
                    id = 9,
                    name = "Kattpassning",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 3)
                },
                new Subcategory
                {
                    id = 11,
                    name = "�vrigt",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 3)
                },
                new Subcategory
                {
                    id = 12,
                    name = "Gr�sklippning",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 4)
                },
                new Subcategory
                {
                    id = 13,
                    name = "Rensning m.m.",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 4)
                },
                new Subcategory
                {
                    id = 14,
                    name = "Sn�skottning",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 4)
                },
                new Subcategory
                {
                    id = 15,
                    name = "�vrigt",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 4)
                },
                new Subcategory
                {
                    id = 16,
                    name = "L�xhj�lp �lder 7-9 �r",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 5)
                },
                new Subcategory
                {
                    id = 17,
                    name = "L�xhj�lp �lder 10-12 �r",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 5)
                },
                new Subcategory
                {
                    id = 18,
                    name = "L�xhj�lp �lder 13-15 �r",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 5)
                },
                new Subcategory
                {
                    id = 19,
                    name = "�vrigt",
                    description = "",
                    category = context.categories.FirstOrDefault(c => c.id == 5)
                }
                );

            context.subsubcategories.AddOrUpdate
                (
                s => s.id,
                new Subsubcategory
                {
                    id = 1,
                    description = "",
                    name = "Svenska",
                    subcategory = context.subcategories.FirstOrDefault(s => s.id == 16)
                },
                new Subsubcategory
                {
                    id = 2,
                    description = "",
                    name = "Matematik",
                    subcategory = context.subcategories.FirstOrDefault(s => s.id == 16)
                },
                new Subsubcategory
                {
                    id = 3,
                    description = "",
                    name = "Naturvetenskap",
                    subcategory = context.subcategories.FirstOrDefault(s => s.id == 16)
                },
                new Subsubcategory
                {
                    id = 4,
                    description = "",
                    name = "Geografi",
                    subcategory = context.subcategories.FirstOrDefault(s => s.id == 16)
                },
                new Subsubcategory
                {
                    id = 5,
                    description = "",
                    name = "Svenska",
                    subcategory = context.subcategories.FirstOrDefault(s => s.id == 17)
                },
                new Subsubcategory
                {
                    id = 6,
                    description = "",
                    name = "Matematik",
                    subcategory = context.subcategories.FirstOrDefault(s => s.id == 17)
                },
                new Subsubcategory
                {
                    id = 7,
                    description = "",
                    name = "Naturvetenskap",
                    subcategory = context.subcategories.FirstOrDefault(s => s.id == 17)
                },
                new Subsubcategory
                {
                    id = 8,
                    description = "",
                    name = "Geografi",
                    subcategory = context.subcategories.FirstOrDefault(s => s.id == 17)
                },
                new Subsubcategory
                {
                    id = 9,
                    description = "",
                    name = "Svenska",
                    subcategory = context.subcategories.FirstOrDefault(s => s.id == 18)
                },
                new Subsubcategory
                {
                    id = 10,
                    description = "",
                    name = "Matematik",
                    subcategory = context.subcategories.FirstOrDefault(s => s.id == 18)
                },
                new Subsubcategory
                {
                    id = 11,
                    description = "",
                    name = "Naturvetenskap",
                    subcategory = context.subcategories.FirstOrDefault(s => s.id == 18)
                },
                new Subsubcategory
                {
                    id = 12,
                    description = "",
                    name = "Geografi",
                    subcategory = context.subcategories.FirstOrDefault(s => s.id == 18)
                }
                );
        }
    }
}
