using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace login.Services.LostPw
{
    class LostPwEmailSender
    {
        string emailTo;

        public LostPwEmailSender(string emailTo)
        {
            this.emailTo = emailTo;
        }  
        public void send()
        {
            MailMessage mm = new MailMessage("baloghbencefacebook@gmail.com", emailTo);
            mm.Subject = "Forgotten Password";
            mm.Body = "<html name="+emailTo+"><h1>elfelejtett jelszó</h1><p>Új jelszó megadásához kattintson <a href='./WebSite/index.html'>erre </html>a linkre</p>";

            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("baloghbencefacebook", JELSZÓÓÓÓÓ);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }
    }
}
