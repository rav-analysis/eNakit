using System.ComponentModel.DataAnnotations;

namespace DijeljeniBlazor.Modeli
{
    public class KreirajKatalogStavkuZahtjev
    {
        public int KatalogTipId { get; set; }

        public int KatalogBrendId { get; set; }

        [Required(ErrorMessage = "Polje Naziv je potrebno popuniti")]
        public string Naziv { get; set; } = string.Empty;

        [Required(ErrorMessage = "Polje Opis je potrebno popuniti")]
        public string Opis { get; set; } = string.Empty;

        // decimal(18,2)
        [RegularExpression(@"^\d+(\.\d{0,2})*$", ErrorMessage = "Polje Cijena mora biti pozitivan broj sa maksimalno dvije decimale.")]
        [Range(0.01, 1000)]
        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; } = 0;
        public string SlikaUri { get; set; } = string.Empty;
        public string SlikaBase64 { get; set; } = string.Empty;
        public string SlikaNaziv { get; set; } = string.Empty;
    }
}


        

     

    }
}

