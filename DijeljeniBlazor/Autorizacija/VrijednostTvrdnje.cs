using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijeljeniBlazor.Autorizacija
{
    class VrijednostTvrdnje
    {
        public VrijednostTvrdnje()
        {
        }
        public VrijednostTvrdnje(string tip, string vrijednost)
        {
            Tip = tip;
            Vrijednost = vrijednost;
        }
        public string Tip { get; set; }
        public string Vrijednost { get; set; }
    }
}

      