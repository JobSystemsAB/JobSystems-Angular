using MvcWebRole.Database.Helper;
using MvcWebRole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole.Api.Models
{
    public class ClientView
    {
        public int id { get; set; }

        public virtual IEnumerable<int> assignmentIds { get; set; }

        public string organisationNumber { get; set; }

        public string companyName { get; set; }

        public string streetAddress { get; set; }

        public string streetAddress2 { get; set; }

        public string postalCode { get; set; }

        public string postTown { get; set; }

        public string country { get; set; }

        public string visitAddress { get; set; }

        public string contactPersonName { get; set; }

        public string contactPersonPhone { get; set; }

        public string emailAddress { get; set; }

        public string phoneNumber { get; set; }

        public string SNI { get; set; }

        public string invoiceEmailAddress { get; set; }

        public string invoiceEmailAddressCopy { get; set; }

        public string password { get; set; }

        public string created { get; set; }

        public string updated { get; set; }

        public bool? enabled { get; set; }





        public string displayName { get { return this.companyName + " (" + this.organisationNumber + ")"; } }


        


        public ClientView()
        {
        }

        public ClientView(Client client)
        {
            AutoMapper.Mapper.CreateMap<Client, ClientView>();
            AutoMapper.Mapper.Map<Client, ClientView>(client, this);
            this.assignmentIds = client.assignments.Select(p => p.id);
            this.created = client.created.ToString().Replace('T', ' ');
            this.updated = client.updated.ToString().Replace('T', ' ');
        }

        public Client convert(EntityFrameworkContext context)
        {
            //var client = new Client();

            //AutoMapper.Mapper.CreateMap<ClientView, Client>();
            //AutoMapper.Mapper.Map<ClientView, Client>(this, client);

            //if (this.assignmentIds != null)
            //    foreach (var assignment in context.assignments.Where(a => this.assignmentIds.Contains(a.id)))
            //        client.assignments.Add(assignment);

            //return client;

            return null;
        }
    }
}