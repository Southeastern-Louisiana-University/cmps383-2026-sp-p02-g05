using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Selu383.SP26.Api.Features.Locations;
using Selu383.SP26.Api.Features.Users;



namespace Selu383.SP26.Api.Data;

public class DataContext : IdentityDbContext<
    User, Role, int,
    IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Location> Locations { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserRole>(b =>
        { 
            b.HasKey(ur => new { ur.UserId, ur.RoleId });

            b.HasOne(ur => ur.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            b.HasOne(ur => ur.Role)
            .WithMany(u => u.Users)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

        });
        // find all the "IEntityTypeConfiguration<TEntity>" implementations in this assembly and apply them
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}