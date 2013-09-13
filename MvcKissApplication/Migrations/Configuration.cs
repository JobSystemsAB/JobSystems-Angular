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
                    id = 4,
                    description = "",
                    name = "St�dning",
                    salary = 130
                },
                new Category
                {
                    id = 8,
                    description = "",
                    name = "Husdjurspassning",
                    salary = 130,                    
                },
                new Category
                {
                    id = 12,
                    description = "",
                    name = "Tr�dg�rdsarbete",
                    salary = 130
                },
                new Category
                {
                    id = 16,
                    description = "",
                    name = "L�xhj�lp, heml�xor m.m.",
                    salary = 130
                },
                new Category
                {
                    id = 36,
                    description = "",
                    name = "�vrigt",
                    salary = 130
                },
                new Category
                {
                    id = 37,
                    description = "",
                    name = "Sn�skottning",
                    salary = 130
                }
                );

            context.categories.AddOrUpdate
            (
                c => c.id,
                new Category
                {
                    id = 2,
                    name = "Barnvakt akut",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 1)
                },
                new Category
                {
                    id = 3,
                    name = "Barnvakt kontinuerligt",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 1)
                },
                new Category
                {
                    id = 38,
                    name = "�vrigt",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 1)
                },
                new Category
                {
                    id = 5,
                    name = "St�dning en g�ng",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 4)
                },
                new Category
                {
                    id = 6,
                    name = "St�dning kontinuerligt",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 4)
                },
                new Category
                {
                    id = 7,
                    name = "�vrigt",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 4)
                },
                new Category
                {
                    id = 9,
                    name = "Hundpassning",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 8)
                },
                new Category
                {
                    id = 10,
                    name = "Kattpassning",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 8)
                },
                new Category
                {
                    id = 11,
                    name = "�vrigt",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 8)
                },
                new Category
                {
                    id = 13,
                    name = "Rensning m.m.",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 12)
                },
                new Category
                {
                    id = 14,
                    name = "Sn�skottning",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 12)
                },
                new Category
                {
                    id = 15,
                    name = "�vrigt",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 12)
                },
                new Category
                {
                    id = 29,
                    name = "L�xhj�lp �lder 13-15 �r",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 16)
                },
                new Category
                {
                    id = 23,
                    name = "L�xhj�lp �lder 10-12 �r",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 16)
                },
                new Category
                {
                    id = 17,
                    name = "L�xhj�lp �lder 7-9 �r",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 16)
                }
            );

            context.categories.AddOrUpdate
            (
                c => c.id,
                new Category
                {
                    id = 18,
                    description = "",
                    name = "Svenska",
                    parent = context.categories.FirstOrDefault(s => s.id == 17)
                },
                new Category
                {
                    id = 19,
                    description = "",
                    name = "Matematik",
                    parent = context.categories.FirstOrDefault(s => s.id == 17)
                },
                new Category
                {
                    id = 20,
                    description = "",
                    name = "Naturvetenskap",
                    parent = context.categories.FirstOrDefault(s => s.id == 17)
                },
                new Category
                {
                    id = 21,
                    description = "",
                    name = "Geografi",
                    parent = context.categories.FirstOrDefault(s => s.id == 17)
                },
                new Category
                {
                    id = 22,
                    description = "",
                    name = "�vrigt",
                    parent = context.categories.FirstOrDefault(s => s.id == 17)
                },
                new Category
                {
                    id = 24,
                    description = "",
                    name = "Svenska",
                    parent = context.categories.FirstOrDefault(s => s.id == 23)
                },
                new Category
                {
                    id = 25,
                    description = "",
                    name = "Matematik",
                    parent = context.categories.FirstOrDefault(s => s.id == 23)
                },
                new Category
                {
                    id = 26,
                    description = "",
                    name = "Naturvetenskap",
                    parent = context.categories.FirstOrDefault(s => s.id == 23)
                },
                new Category
                {
                    id = 27,
                    description = "",
                    name = "Geografi",
                    parent = context.categories.FirstOrDefault(s => s.id == 23)
                },
                new Category
                {
                    id = 28,
                    description = "",
                    name = "�vrigt",
                    parent = context.categories.FirstOrDefault(s => s.id == 23)
                },
                new Category
                {
                    id = 30,
                    description = "",
                    name = "Svenska",
                    parent = context.categories.FirstOrDefault(s => s.id == 29)
                },
                new Category
                {
                    id = 31,
                    description = "",
                    name = "Matematik",
                    parent = context.categories.FirstOrDefault(s => s.id == 29)
                },
                new Category
                {
                    id = 32,
                    description = "",
                    name = "Naturvetenskap",
                    parent = context.categories.FirstOrDefault(s => s.id == 29)
                },
                new Category
                {
                    id = 33,
                    description = "",
                    name = "Geografi",
                    parent = context.categories.FirstOrDefault(s => s.id == 29)
                },
                new Category
                {
                    id = 34,
                    description = "",
                    name = "�vrigt",
                    parent = context.categories.FirstOrDefault(s => s.id == 29)
                },
                new Category
                {
                    id = 35,
                    name = "�vrigt",
                    description = "",
                    parent = context.categories.FirstOrDefault(c => c.id == 16)
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

        }
    }
}
