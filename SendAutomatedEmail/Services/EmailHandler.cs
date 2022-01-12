using SendAutomatedEmail.Interfaces;
using SendAutomatedEmail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendAutomatedEmail.Services
{
    public class EmailHandler : IEmailHandler
    {
        protected readonly string HostServer = "smtp.gmail.com";

        public async Task SendEmail(EmailModel model, string username, string password)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(model.EmailFrom, model.EmailFromName);

                    //Add all the CCs into the email
                    if (model.CCs.Count() > 0)
                    {
                        foreach (var cc in model.CCs)
                        {
                            message.CC.Add(new MailAddress(cc));
                        }
                    }

                    //Add all the BCCs into the email
                    if (model.BCCs.Count() > 0)
                    {
                        foreach (var bcc in model.BCCs)
                        {
                            message.Bcc.Add(new MailAddress(bcc));
                        }
                    }

                    //Add all the Recipients (TO) into the email
                    if (model.Recipients.Count() > 0)
                    {
                        foreach (var recipients in model.Recipients)
                        {
                            message.To.Add(new MailAddress(recipients));
                        }
                    }

                    message.Subject = model.Subject;
                    message.Body = model.Body;
                    message.IsBodyHtml = true;

                    using (var smtpClient = new SmtpClient(HostServer, 587))
                    {
                        smtpClient.Credentials = new NetworkCredential(username, password);
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.EnableSsl = true;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Send(message);
                    }
                }
               await Task.FromResult(0);
            }
            catch
            {
                throw;
            }
        }
    }
}
