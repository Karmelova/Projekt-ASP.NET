using Microsoft.EntityFrameworkCore;

namespace YourITMatch.Models
{
    public class YourITMatchDBContext : DbContext
    {
        public DbSet<CompanyModel> Company { get; set; }
        public DbSet<CompanyAddressModel> CompanyAddress { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=.\Data\YourITMatchDB.db");
    }
}