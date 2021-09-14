using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Potvrdite Vaš E-mail",
                $"Molimo Vas da potvrdite Vaš račun klikom na ovaj link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
