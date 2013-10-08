using PageAndServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace PageAndServices.Helpers
{
    public class GoogleMail
    {

        public void send(IEnumerable<Employee> employees)
        {
            var fromAddress = new MailAddress("info@jobsystems.se", "Job Systems AB");
            const string fromPassword = "infoPassword";
            const string subject = "[JobSystems] New job near you";
            const string body = "We found you a new job";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage())
            {
                message.Subject = subject;
                message.Body = body;
                message.From = fromAddress;

                foreach( var employee in employees )
                {
                    var toAddress = new MailAddress(employee.emailAddress, employee.firstName + " " + employee.lastName);
                    message.To.Add(toAddress);
                }

                smtp.Send(message);
            }
        }

    }
}