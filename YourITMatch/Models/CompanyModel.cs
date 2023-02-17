using System.ComponentModel.DataAnnotations;

namespace YourITMatch.Models
{
    public class CompanyModel
    {
        public ICollection<UserCompany>? UserCompanies { get; set; }

        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string NIP { get; set; }

        [Required]
        public string Regon { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Voivodeship { get; set; }

        [Required]
        public string Street { get; set; }

        public enum _CompanySize
        {
            Micro,
            Small,
            Medium,
            Large
        }

        public _CompanySize? CompanySize { get; set; }

        public DateOnly? CompanyEstablished { get; set; }

        [Url]
        public string? CompanyWebsite { get; set; }
    }
}