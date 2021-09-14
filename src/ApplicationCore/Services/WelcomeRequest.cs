using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class WelcomeRequest
    {
        public string ToEmail { get; set; } 
        public string UserName { get; set; }
    }
}
