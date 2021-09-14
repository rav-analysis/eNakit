using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using BlazorInputFile;

namespace BlazorShared.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }

        public int CatalogTypeId { get; set; }
        public string CatalogType { get; set; } = "NotSet";

        public int CatalogBrandId { get; set; }
        public string CatalogBrand { get; set; } = "NotSet";

        [Required(ErrorMessage = "Polje Ime je potrebno popuniti.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Polje Opis je potrebno popuniti.")]
        public string Description { get; set; }

        // decimal(18,2)
        [RegularExpression(@"^\d+(\.\d{0,2})*$", ErrorMessage = "Polje Cijena mora biti pozitivan broj sa maksimalno dvije decimale.")]
        [Range(0.01, 1000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string PictureUri { get; set; }
        public string PictureBase64 { get; set; }
        public string PictureName { get; set; }

        private const int ImageMinimumBytes = 512000;

        public static string IsValidImage(string pictureName, string pictureBase64)
        {
            if (string.IsNullOrEmpty(pictureBase64))
            {
                return "Fajl nije pronađen!";
            }
            var fileData = Convert.FromBase64String(pictureBase64);

            if (fileData.Length <= 0)
            {
                return "Dužina fajla je 0!";
            }

            if (fileData.Length > ImageMinimumBytes)
            {
                return "Maksimalna veličina je 512KB.";
            }

            if (!IsExtensionValid(pictureName))
            {
                return "Odabrani fajl nije slika.";
            }

            return null;
        }

        public static async Task<string> DataToBase64(IFileListEntry fileItem)
        {
            using ( var reader = new StreamReader(fileItem.Data))
            {
                using (var memStream = new MemoryStream())
                {
                    await reader.BaseStream.CopyToAsync(memStream);
                    var fileData = memStream.ToArray();
                    var encodedBase64 = Convert.ToBase64String(fileData);

                    return encodedBase64;
                }
            }
        }

        private static bool IsExtensionValid(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            return string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase);
        }
    }
}
