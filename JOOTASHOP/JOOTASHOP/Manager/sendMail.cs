using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Configuration;
using System.Net;
using System.Data.OleDb;

namespace JOOTASHOP.Manager
{
    public class sendMail
    {
        public int mail(string Subject, string Message)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("shams3309243@gmail.com");

                //Enter your email blow and also change in database too

                message.To.Add(new MailAddress("shams3309243@gmail.com"));
                message.Subject = Subject;
                message.Body = Message;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("shams3309243@gmail.com", "090078601");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }





        }

    }
}