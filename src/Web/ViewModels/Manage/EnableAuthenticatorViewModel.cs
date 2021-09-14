using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.eShopWeb.Web.ViewModels.Manage
{
    public class EnableAuthenticatorViewModel
    {
        [Required]
        [StringLength(7, ErrorMessage = "{0} mora imati najmanje {2} a {1} najviše karaktera.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Verifikacijski kod")]
        public string Code { get; set; }

        [ReadOnly(true)]
        public string SharedKey { get; set; }

        public string AuthenticatorUri { get; set; }
    }
}
