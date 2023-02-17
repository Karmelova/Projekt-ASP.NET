using System.ComponentModel.DataAnnotations;

namespace YourITMatch.Models
{
    public class CompanyModel
    {
        public string? AddedBy { get; set; }

        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        public string? Description { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$")]
        public string NIP { get; set; }

        [Required]
        [RegularExpression(@"^\d{9}(\d{5})?$")]
        public string Regon { get; set; }

        [Required]
        [Display(Name = "Kod Pocztowy")]
        public string PostCode { get; set; }

        [Required]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Województwo")]
        public string Voivodeship { get; set; }

        [Required]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        public enum _CompanySize
        {
            [Display(Name = "< 10")]
            Micro,

            [Display(Name = "10 - 49")]
            Small,

            [Display(Name = "50 - 199")]
            Medium,

            [Display(Name = "200+")]
            Large
        }

        [Display(Name = "Pracownicy")]
        public _CompanySize? CompanySize { get; set; }

        [Display(Name = "Rok założenia")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Rok założenia powinien składać się z 4 cyfr.")]
        public DateOnly? CompanyEstablished { get; set; }

        [Url]
        [Display(Name = "Strona internetowa")]
        public string? CompanyWebsite { get; set; }

        public ICollection<JobOfferModel>? JobOffers { get; set; }
    }
}