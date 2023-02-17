using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using YourITMatch.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            Database.EnsureCreated();
        }
    }
}