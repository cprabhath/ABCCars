using ABCCars.Validations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ABCCars.Utils
{
    internal class OrderApproveMail
    {
        public bool SendOrderApproveMail(string email)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("librarylkactivation@gmail.com", "ocma xovk fjdn hfhc"),
                    EnableSsl = true
                };
                // ===========================================================

                // ================ Read the email template ==================
                string htmlTemplatePath = "./OrderApprove.html";
                string htmlTemplate = File.ReadAllText(htmlTemplatePath);
                // ===========================================================

                // ========= Replace the placeholder with the token ==========
                string body = htmlTemplate.Replace("{{TOKEN}}", "Congratulations!!!");
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

                MessageBox.Show("Order has been approved", utils.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }catch(Exception ex)
            {
                MessageBox.Show("Error sending email " + ex.Message, utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
