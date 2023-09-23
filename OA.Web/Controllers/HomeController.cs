using Microsoft.AspNetCore.Mvc;
using OA.Web.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace OA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //srsgixjaiybtihaj
           
                try
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress("sm5309003@gmail.com");
                    message.To.Add(new MailAddress("sumitm@chetu.com"));
                    message.Subject = "Testing SMTP mail";
                    message.IsBodyHtml = true; //to make message body as html
                    message.Body = "Hello testing email";
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com"; //for gmail host
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("sm5309003@gmail.com", "srsgixjaiybtihaj");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                   // smtp.Send(message);
                }
                catch (Exception) { }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}