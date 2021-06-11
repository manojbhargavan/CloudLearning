using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Photos.Model;
using Photos.Services.Data;
using Photos.Services.Email;

namespace Photos.Controllers
{
    public class AppController : Controller
    {
        private readonly IPhotoRepository photoRepository;
        private readonly ILogger<AppController> logger;
        private readonly IEmailService emailService;

        public AppController(IPhotoRepository photoRepository, ILogger<AppController> logger, IEmailService emailService)
        {
            this.logger = logger;
            this.emailService = emailService;
            this.photoRepository = photoRepository;
        }
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet("/Contact")]
        public IActionResult Contact()
        {
            photoRepository.PrintRepoType();
            return View();
        }

        [HttpPost("/Contact")]
        public IActionResult Contact(ContactViewModel contactViewModel)
        {
            //Model State is not valid or emulate a failure
            if (!ModelState.IsValid || contactViewModel.FailMail)
            {
                logger.LogWarning($"Model is not valid: {contactViewModel.ToString()}");
                ViewBag.MailSent = false;
            }
            else
            {
                //Conceptual Builder
                emailService.AddBody($"From: {contactViewModel.Name}, Message: {contactViewModel.Message}")
                            .AddFromAddress(contactViewModel.Email)
                            .AddSubject(contactViewModel.Subject)
                            .AddToAddress("sysadmin@somedomai.com")
                            .SendMail();
                ModelState.Clear();
                ViewBag.MailSent = true;
                ViewBag.MailDetails = emailService.ToString();
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}