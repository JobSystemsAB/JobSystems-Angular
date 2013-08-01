namespace MvcApplication1.Migrations
{
    using MvcApplication1.Database.Helpers;
    using MvcApplication1.Database.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcApplication1.Database.Helpers.EntityFrameworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcApplication1.Database.Helpers.EntityFrameworkContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.administrators.AddOrUpdate(
                a => a.username,
                new Administrator
                {
                    username = "admin",
                    password = "admin",
                    created = DateTime.UtcNow,
                    updated = DateTime.UtcNow,
                    enabled = true,
                }
            );

            context.pets.AddOrUpdate(
                a => a.name,
                new Pet { name = "Hund" },
                new Pet { name = "Katt" },
                new Pet { name = "Häst" },
                new Pet { name = "Marsvin" },
                new Pet { name = "Kanin" },
                new Pet { name = "Fågel" }
            );

            context.privateCustomers.AddOrUpdate(
                c => c.personalNumber,
                new CustomerPrivate
                {
                    address = new Address
                    {
                        country = "Sweden",
                        postalCode = "12954",
                        postalTown = "Hägersten",
                        street = "Doktor Widerströms Gata",
                        streetNumber = "36",
                        latitude = 58,
                        longitude = 17
                    },
                    created = DateTime.UtcNow,
                    updated = DateTime.UtcNow,
                    enabled = true,
                    emailAddress = "misael@jobsystems.se",
                    firstName = "Misael",
                    lastName = "Berrios Private",
                    password = "misse",
                    personalNumber = "8608120336",
                    phoneNumber = "0704333005",
                    propertyName = "property"
                }
            );

            context.companyCustomers.AddOrUpdate(
                c => c.organisationNumber,
                new CustomerCompany
                {
                    address = new Address
                    {
                        country = "Sweden",
                        postalCode = "12954",
                        postalTown = "Hägersten",
                        street = "Doktor Widerströms Gata",
                        streetNumber = "36",
                        latitude = 58,
                        longitude = 17
                    },
                    companyName = "Misael Company",
                    created = DateTime.UtcNow,
                    updated = DateTime.UtcNow,
                    emailAddress = "misael@jobsystems.se",
                    enabled = true,
                    organisationNumber = "19860812",
                    password = "misse",
                    phoneNumber = "0704333005"
                }
                );

            context.employees.AddOrUpdate(
                e => e.personalNumber,
                new Employee
                {
                    address = new Address
                    {
                        country = "Sweden",
                        postalCode = "12954",
                        postalTown = "Hägersten",
                        street = "Doktor Widerströms Gata",
                        streetNumber = "36",
                        latitude = 58,
                        longitude = 17
                    },
                    bankAccountNumber = "Bank Number",
                    bankClearingNumber = "Bank Clearing",
                    bankName = "Handelsbanken",
                    emailAddress = "misael@jobsystems.se",
                    enabled = true,
                    firstName = "Misael",
                    hourSalary = "120",
                    infoText = "Trevlig o klyftig grabb",
                    lastName = "Berrios Salas",
                    mobilePhoneNumber = "0704333005",
                    password = "misse",
                    personalNumber = "8608120336",
                    phoneNumber = "n/a",
                    updated = DateTime.UtcNow
                }
            );

            //context.pet_employees.AddOrUpdate(
            //    pe => pe.employeeId,
            //    new Employee_Pet
            //    {
            //        employeeId = context.employees.FirstOrDefault(e => e.personalNumber == "8608120336").id,
            //        employee = context.employees.FirstOrDefault(e => e.personalNumber == "8608120336")
            //    }
            //);

        }
    }
}
