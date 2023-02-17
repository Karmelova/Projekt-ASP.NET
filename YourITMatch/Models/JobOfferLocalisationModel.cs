using System.ComponentModel.DataAnnotations;

namespace YourITMatch.Models
{
    public class JobOfferLocalisationModel
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        public JobOfferModel JobOfferId { get; set; }

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