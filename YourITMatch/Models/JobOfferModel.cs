using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace YourITMatch.Models
{
    public class JobOfferModel
    {
        public int Id { get; set; }
        public CompanyModel CompanyID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateAdded { get; set; }
        public int CompanyId { get; set; }
        public int JobCategoryId { get; set; }
        public bool Remote { get; set; }
    }
}