using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace eFahionStore.Common.Helpers
{
    public class MailHelper
    {
        public static bool SendMail(string subject, string message, string ToEmail)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                MailAddress maddress = new MailAddress("vinhk233@gmail.com", "Coza Store system");
                mailMessage.From = maddress;
                mailMessage.To.Add(ToEmail.Trim());
                mailMessage.Subject = subject;
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;

                string sendEmailsFrom = "vinhk233@gmail.com"; 
                string sendEmailsFromPassword = "Eyasuo147852";

                NetworkCredential cred = new NetworkCredential(sendEmailsFrom, sendEmailsFromPassword);
                SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);

                mailClient.EnableSsl = true;
                mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = cred;
                mailClient.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
