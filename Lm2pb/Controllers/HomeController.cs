using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using Lm2pb.Models;
using System.Threading.Tasks;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc.Attributes;

namespace Lm2pb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Thanks()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(Contact model)
        {

            this.IsCaptchaValid("captcha not valid");

            try
            {
                if (ModelState.IsValid)
                {

                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p> Reply to {3}";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress("uphayled@gmail.com"));  // replace with valid value 
                    message.From = new MailAddress(model.Email);  // replace with valid value
                    message.Subject = "Contact Me";
                    message.Body = string.Format(body, model.FirstName, model.LastName, model.Comments,model.Email);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        await smtp.SendMailAsync(message);
                        return RedirectToAction("Thanks");
                    }

                }
                return View(model);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

    }
}