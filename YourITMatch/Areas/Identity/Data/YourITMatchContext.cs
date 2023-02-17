using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YourITMatch.Areas.Identity.Data;
using YourITMatch.Models;
using System.Security.Claims;

public class YourITMatchContext : IdentityDbContext<IdentityUser>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DbSet<CompanyModel> Companies { get; set; }

    public YourITMatchContext(DbContextOptions<YourITMatchContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        Database.EnsureCreated();
    }

    public YourITMatchContext(DbContextOptions<YourITMatchContext> options)
        : base(options)
    {
    }

    public override int SaveChanges()
    {
        var addedEntities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added)
            .ToList();

        foreach (var entity in addedEntities)
        {
            if (entity.Entity is CompanyModel)
            {
                var company = (CompanyModel)entity.Entity;

                // Get the currently logged in user's ID
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                // Assign the currently logged in user as the owner of the company
                company.AddedBy = userId;
            }
        }

        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    private class ApplicationUserEntityConfiguration :
        IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255);
        }
    }
}