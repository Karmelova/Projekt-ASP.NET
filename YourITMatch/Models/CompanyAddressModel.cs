using System.ComponentModel.DataAnnotations;

namespace YourITMatch.Models
{
    public class CompanyAddressModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int CompanyID { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Voivodeship { get; set; }

        [Required]
        public string Street { get; set; }
    }
}