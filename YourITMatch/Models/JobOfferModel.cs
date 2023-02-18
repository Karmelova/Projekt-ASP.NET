using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace YourITMatch.Models
{
    public class JobOfferModel
    {
        public string? AddedBy { get; set; }

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public CompanyModel? Company { get; set; }

        [Required(ErrorMessage = "Podanie tytułu oferty jest wymagane.")]
        [Display(Name = "Tytuł oferty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Podanie opisu oferty jest wymagane.")]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Podanie wynagrodzenia jest wymagane.")]
        [Display(Name = "Wynagrodzenie od")]
        public int SalaryFrom { get; set; }

        [Required(ErrorMessage = "Podanie wynagrodzenia jest wymagane.")]
        [Display(Name = "Wynagrodzenie do")]
        public int SalaryTo { get; set; }

        [Display(Name = "Praca zdalna")]
        public bool Remote { get; set; }
    }
}