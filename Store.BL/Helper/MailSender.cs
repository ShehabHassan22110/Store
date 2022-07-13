using Store.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Helper
{
  public  class MailSender
    {
        public static string SendMail(MailVM model)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("sehab.hassa16612@gmail.com", "0125810405");
                smtp.Send("sehab.hassa16612@gmail.com", model.Mail, model.Title, model.Message);

                var result = "Mail Sent Successfully";
                return result;
            }
            catch (Exception )
            {
                var result = "Faild";
                return result;
            }
        }
    }
}
