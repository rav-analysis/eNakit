using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            MailRequest testRequest = new MailRequest();
            testRequest.ToEmail = "christelle.wolf97@ethereal.email";
            testRequest.Subject = "eNakit narudžba";
            testRequest.Body = "Poštovani, Vaša narudžba je uspješno evidentirana. Tokom idućih 10 radnih dana očekujte dostavu na adresu. Hvala Vam na povjerenju";
            try
            {
                await mailService.SendEmailAsync(testRequest);
                return Redirect("../../../");
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpPost("welcome")]
        public async Task<IActionResult> SendWelcomeMail([FromForm] WelcomeRequest request)
        {
            WelcomeRequest testRequest = new WelcomeRequest();
            testRequest.UserName = "Christelle Wolf";
            testRequest.ToEmail = "christelle.wolf97@ethereal.email";
            try
            {
                await mailService.SendWelcomeEmailAsync(testRequest);
                return Redirect("../../../"); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
