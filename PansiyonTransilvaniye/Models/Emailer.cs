using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace PansiyonTransilvaniye.Models
{
    public class Emailer
    {
        public static string Email
        {
            get
            {
                return "mmuhammetorazow@gmail.com";
            }
        }
        public static void Send(string text)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(Email);
            msg.Body = text;
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(msg);
        }
    }
}