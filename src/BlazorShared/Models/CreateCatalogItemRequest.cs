using System.ComponentModel.DataAnnotations;

namespace BlazorShared.Models
{
    public class CreateCatalogItemRequest
    {
        public int CatalogTypeId { get; set; }

        public int CatalogBrandId { get; set; }

        [Required(ErrorMessage = "Polje Ime je potrebno popuniti")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Polje Opis je potrebno popuniti")]
        public string Description { get; set; } = string.Empty;

        // decimal(18,2)
        [RegularExpression(@"^\d+(\.\d{0,2})*$", ErrorMessage = "Polje Cijena mora biti pozitivan broj sa maksimalno dvije decimale.")]
        [Range(0.01, 1000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } = 0;

        public string PictureUri { get; set; } = string.Empty;
        public string PictureBase64 { get; set; } = string.Empty;
        public string PictureName { get; set; } = string.Empty;

    }
}
