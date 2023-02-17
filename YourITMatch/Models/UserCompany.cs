using YourITMatch.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace YourITMatch.Models
{
    public class UserCompany
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public CompanyModel Company { get; set; }
    }
}