using System.Collections.Generic;


namespace DijeljeniBlazor.Autorizacija
{
    class InfoKorisnik
    {
        public static readonly InfoKorisnik Anonimni = new InfoKorisnik();
        public bool JeLiAutentificiran { get; set; }
        public string NazivTvrdnjaTip { get; set; }
        public string RolaTvrdnjaTip { get; set; }
        public string Token { get; set; }
        public IEnumerable<VrijednostTvrdnje> Tvrdnje { get; set; }
    }
}


        
