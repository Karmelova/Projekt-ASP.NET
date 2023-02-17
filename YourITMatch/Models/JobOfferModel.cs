using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace YourITMatch.Models
{
    public class JobOfferModel
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal SalaryFrom { get; set; }

        [Required]
        public decimal SalaryTo { get; set; }

        [Required]
        public _JobCategory JobCategory { get; set; }

        public bool Remote { get; set; }

        public enum _JobCategory
        {
            JS,
            HTML,
            PHP,
            RUBY,
            PYTHON,
            JAVA,
            DOTNET,
            SCALA,
            C,
            GO,
            MOBILE,
            TESTING,
            DEVOPS,
            ADMIN,
            UXUI,
            PM,
            GAME,
            ANALYTICS,
            SECURITY,
            DATA,
            SUPPORT,
            ARCHITECTURE,
            OTHER,
        }
    }
}