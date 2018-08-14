using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Http;

namespace YesGuruji.Controllers
{
    public class ContactController : ApiController
    {
        // GET: api/Contact
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Contact/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contact
        public void Post([FromBody]ContactModel model)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                string smtpHost = ConfigurationManager.AppSettings["SmtpHost"].ToString();
                string smtpUser = ConfigurationManager.AppSettings["SmtpUser"].ToString();
                string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"].ToString();

                string subject = string.Empty;
                string body = string.Empty;
                string mailUrl = string.Empty;

                subject = "New Contact";                
               
                message.From = new MailAddress(ConfigurationManager.AppSettings["SmtpUser"].ToString());
                message.To.Add(ConfigurationManager.AppSettings["ToAddress"].ToString());

                message.IsBodyHtml = true;
                message.Headers.Add("Content-Type", "content=text/html; charset=\"UTF-8\"");              
                message.Subject = subject;
                string path = HttpContext.Current.Server.MapPath("~/EmailTemplate/ContactHtml.html");

                using (StreamReader reader = new StreamReader(path))
                {
                    body = reader.ReadToEnd();
                }

                body = body.Replace("{categoty}", model.Category);
                body = body.Replace("{firstName}", model.FirstName);
                body = body.Replace("{email}", model.Email);
                body = body.Replace("{street}", model.Street);
                body = body.Replace("{mobilePhone}", model.MobilePhone);
                body = body.Replace("{subject}", model.Subject);
                body = body.Replace("{comment}", model.Comment);                
                message.Body = body;

                smtpClient.Host = smtpHost;   // We use gmail as our smtp client
                smtpClient.Port = 2525;           
                smtpClient.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPassword);

                if (!string.IsNullOrWhiteSpace(subject) && !string.IsNullOrWhiteSpace(body))
                {
                    smtpClient.Send(message);
                }
            }
            catch(Exception ex)
            {
                throw;
            }           
           
        }

        // PUT: api/Contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contact/5
        public void Delete(int id)
        {
        }
    }

    public class ContactModel
    {
        public string Category { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string MobilePhone { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }
    }
}
