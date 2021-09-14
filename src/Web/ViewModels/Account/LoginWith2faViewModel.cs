using System.ComponentModel.DataAnnotations;

namespace Microsoft.eShopWeb.Web.ViewModels.Account
{
    public class LoginWith2faViewModel
    {
        [Required]
        [StringLength(7, ErrorMessage = "{0} mora imati najmanje {2} a najviše {1} znakova.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Autentifikacijski kod")]
        public string TwoFactorCode { get; set; }

        [Display(Name = "Zapamti ovaj uređaj")]
        public bool RememberMachine { get; set; }

        public bool RememberMe { get; set; }
    }
}
