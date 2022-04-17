using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplicationRypYNP.Services;

namespace WebApplicationRypYNP.Models.EmailModel
{
    public class AlertMessageModel
    {

        string fromLogin = ConfigRypYNP.ProjectName;
        string fromEmail = ConfigRypYNP.ProjectMessage;
        string fromPassword = ConfigRypYNP.ProjectPassword;

        string toEmail = "";



        public async Task SendMessageAsync(string email)
        {
            try
            {
                MailAddress fromAddress = new MailAddress(fromEmail, fromLogin);
                MailAddress toAddress = new MailAddress(toEmail);

                MailMessage message = new MailMessage(fromAddress, toAddress);
                message.Body = ConfigRypYNP.ProjectMessage;
                message.Subject = "Уведомление";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.mail.ru";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromEmail, fromPassword);

                await smtpClient.SendMailAsync(message);
            }
            catch (Exception) { }
        }

    }
}
