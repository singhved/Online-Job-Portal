using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Job_Portal.Models;

namespace Job_Portal.Controllers
{
    public class HomeController : Controller
    {
        private JobContext db = new JobContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Details()
        //{
        //    return View();
        //}
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Testimonials()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public void InsertContactForAnyQuery(string Name, int? Mobile, string Email,string Subject,string Message)
        {
            Procs.InsertContactForAnyQuery(Name, Mobile, Email,Subject,Message);
        }
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Details()
        {
            TempData["Message"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult Details(string ToMail, string Sub, string Body, string CcMail = null, HttpPostedFileBase file = null)
        {
            try
            {
                var message = new MailMessage();
                message.To.Add(ToMail);
                if (!string.IsNullOrEmpty(CcMail))
                    message.CC.Add(CcMail);
                if (file != null)
                {
                    string filename = Path.GetFileName(file.FileName);
                    message.Attachments.Add(new Attachment(file.InputStream, filename));
                }
                message.From = new MailAddress("singhved681@outlook.com");
                message.Subject = Sub;
                message.Body = Body;
                message.IsBodyHtml = false;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "singhved681@outlook.com",
                        Password = "Sigh@123n"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }
                TempData["Message"] = "Mail Sent";
            }
            catch (Exception ex) { TempData["Message"] = ex.Message; }
            return View();
        }
    }
}