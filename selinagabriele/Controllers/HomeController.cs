using selinagabriele.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace selinagabriele.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Selina Gabriele";
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Title = "Selina Gabriele";
            return View();
        }
       
        public ActionResult Contact()
        {
            ContactViewModel contact = new ContactViewModel();

            return PartialView("_ContactPartial",contact);
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel contact)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(contact.Email);//Email which you are getting 
                                                         //from contact us page 
                    message.To.Add("gabrieleselina@gmail.com");//Where mail will be sent 
                    message.Subject = contact.Subject;
                    message.Body = contact.Message;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = true;
                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    ("gabrieleselina@gmail.com", "Josef//95");


                    smtp.Send(message);

                    ModelState.Clear();
                    return Json(new { success = true });

                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                    return Json(new { success = false });
                }
            }
            return PartialView("_ContactPartial", contact);

        }
    }
}