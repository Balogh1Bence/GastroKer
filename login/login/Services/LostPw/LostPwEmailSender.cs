﻿using login.Misc;
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
        mypw n;
        public LostPwEmailSender(string emailTo)
        {
            n = new mypw();
            this.emailTo = emailTo;
        }  
        public void send()
        {
            try
            {
                MailMessage mm = new MailMessage("baloghbencefacebook@gmail.com", emailTo);
                mm.Subject = "Forgotten Password";
                mm.Body = "<html><h1>elfelejtett jelszó</h1><p>Új jelszó megadásához kattintson <a href='../../website/forgottenpw.php?email=" + emailTo + "'>erre</a></html>a linkre</p>";

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;

                NetworkCredential NetworkCred = new NetworkCredential("baloghbencefacebook", n.pw);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 25;
                smtp.Send(mm);
            }
            catch (Exception e)
            {
                try
                {
                    MailMessage mm = new MailMessage("baloghbencefacebook@gmail.com", emailTo);
                    mm.Subject = "Forgotten Password";
                mm.Body = "<html><h1>elfelejtett jelszó</h1><p>Új jelszó megadásához kattintson <a href='../../website/forgottenpw.php?email=" + emailTo + "'>erre</a></html>a linkre</p>";

                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;

                    NetworkCredential NetworkCred = new NetworkCredential("baloghbencefacebook", n.pw);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
                catch (Exception a)
                {
                    try
                    {
                        MailMessage mm = new MailMessage("baloghbencefacebook@gmail.com", emailTo);
                        mm.Subject = "Forgotten Password";
                mm.Body = "<html><h1>elfelejtett jelszó</h1><p>Új jelszó megadásához kattintson <a href='../../website/forgottenpw.php?email=" + emailTo + "'>erre</a></html>a linkre</p>";

                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;

                        NetworkCredential NetworkCred = new NetworkCredential("baloghbencefacebook", n.pw);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 465;
                        smtp.Send(mm);
                    }
                    catch (Exception b)
                    {
                        System.Windows.Forms.MessageBox.Show("hálózati hiba/ nem létező email cím");
                    }
                }
            }
        }
    }
}
