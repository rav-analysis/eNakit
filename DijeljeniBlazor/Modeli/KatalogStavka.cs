using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using BlazorInputFile;

namespace DijeljeniBlazor.Modeli
{
    public class KatalogStavka
    {
        public int Id { get; set; }

        public int KatalogTipId { get; set; }
        public string KatalogTip { get; set; } = "Nedefinisan";

        public int KatalogBrendId { get; set; }
        public string KatalogBrend { get; set; } = "Nedefinisan";

        [Required(ErrorMessage = "Polje Naziv je potrebno popuniti.")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Polje Opis je potrebno popuniti.")]
        public string Opis { get; set; }

        // decimal(18,2)
        [RegularExpression(@"^\d+(\.\d{0,2})*$", ErrorMessage = "Polje Cijena mora biti pozitivan broj sa maksimalno dvije decimale.")]
        [Range(0.01, 1000)]
        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; }

        public string SlikaUri { get; set; }
        public string SlikaBase64 { get; set; }
        public string SlikaNaziv { get; set; }

        private const int SlikaMinimumBajtova = 512000;

        public static string JeLiSlikaValidna(string slikaNaziv, string slikaBase64)
        {
            if (string.IsNullOrEmpty(slikaBase64))
            {
                return "Fajl nije pronađen!";
            }
            var filePodaci = Convert.FromBase64String(slikaBase64);

            if (filePodaci.Length <= 0)
            {
                return "Dužina fajla je 0!";
            }

            if (filePodaci.Length > SlikaMinimumBajtova)
            {
                return "Maksimalna veličina je 512KB.";
            }

            if (!IsExtensionValid(slikaNaziv))
            {
                return "Odabrani fajl nije slika.";
            }

            return null;
        }

        public static async Task<string> PodaciUBase64(IFileListEntry fileStavka)
        {
            using (var citac = new StreamReader(fileStavka.Data))
            {
                using (var memNiz = new MemoryStream())
                {
                    await citac.BaseStream.CopyToAsync(memNiz);
                    var filePodaci = memNiz.ToArray();
                    var enkodiranBase64 = Convert.ToBase64String(filePodaci);

                    return enkodiranBase64;
                }
            }
        }

        private static bool JeLiSlikaValidna(string fileNaziv)
        {
            var ekstenzija = Path.GetExtension(fileNaziv);

            return string.Equals(ekstenzija, ".jpg", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(ekstenzija, ".png", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(ekstenzija, ".gif", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(ekstenzija, ".jpeg", StringComparison.OrdinalIgnoreCase);
        }
    }
}
