using Microsoft.EntityFrameworkCore;
using YourITMatch.Models;

namespace YourITMatch.Models
{
    public class YourITMatchDBContext : DbContext
    {
        public DbSet<CompanyModel> Company { get; set; }
        public DbSet<CompanyAddressModel> CompanyAddress { get; set; }
        public DbSet<JobOfferModel> JobOffer { get; set; }
        public DbSet<JobOfferLocalisationModel> JobOfferLocalisation { get; set; }

        public YourITMatchDBContext(DbContextOptions<YourITMatchDBContext> options) : base(options)
        {
        }
    }
}