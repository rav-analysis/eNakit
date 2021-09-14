using System.Collections.Generic;

namespace DijeljeniBlazor.Modeli
{
    public class StranicaKatalogStavkaOdgovor
    {
        public List<KatalogStavka> KatalogStavke { get; set; } = new List<KatalogStavka>();
        public int BrojStranica { get; set; } = 0;
    }
}

