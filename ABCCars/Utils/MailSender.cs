using System.Net.Mail;
using System.Net;
using System;
using ABCCars.Validations;
using System.Windows.Forms;
using System.IO;

namespace ABCCars.Utils
{
    public class MailSender
    {
        public string SendMail(string email)
        {
            try
            {
                // ============= create random 6 digit number ================
                Random random = new Random();
                int token = random.Next(100000, 999999);
                // ===========================================================

                //============== Create a new SmtpClient object ==============
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("librarylkactivation@gmail.com", "ocma xovk fjdn hfhc"),
                    EnableSsl = true
                };
                // ===========================================================

                // ================ Read the email template ==================
                string htmlTemplatePath = "./EmailTemplete.html";
                string htmlTemplate = File.ReadAllText(htmlTemplatePath);
                // ===========================================================

                // ========= Replace the placeholder with the token ==========
                string body = htmlTemplate.Replace("{{TOKEN}}", token.ToString());
                // ===========================================================

                // =========== Create a new MailMessage object ===============
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("librarylkactivation@gmail.com"),
                    Subject = "ABC Car Trades",
                    Body = body,
                    IsBodyHtml = true
                };
                // ===========================================================

                // ============= the recipient's email address ===============
                mailMessage.To.Add(email);
                // ===========================================================

                // ====================== Send the email =====================
                smtpClient.Send(mailMessage);
                // ===========================================================

                MessageBox.Show("Your token has been send to your email address", utils.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return token.ToString();

            }catch(Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message, utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }
    }
}
