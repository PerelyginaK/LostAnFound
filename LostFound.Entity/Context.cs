using Microsoft.EntityFrameworkCore;
using LostFound.Entity.Models;

namespace LostFound.Entity;
public class Context : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Bureau> Bureaus { get; set; }
    public DbSet<Finding> Findings { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Cities

        builder.Entity<City>().ToTable("cities");
        builder.Entity<City>().HasKey(x => x.Id);

        #endregion

        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);        
        builder.Entity<User>().HasOne(x => x.City)
                                    .WithMany(x => x.Users)
                                    .HasForeignKey(x => x.CityId)
                                    .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region Bureau

        builder.Entity<Bureau>().ToTable("bureaus");
        builder.Entity<Bureau>().HasKey(x => x.Id);
        builder.Entity<Bureau>().HasOne(x => x.City)
                                    .WithMany(x => x.Bureaus)
                                    .HasForeignKey(x => x.CityId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Employee

        builder.Entity<Employee>().ToTable("employees");
        builder.Entity<Employee>().HasKey(x => x.Id);
        builder.Entity<Employee>().HasOne(x => x.Bureau)
                                    .WithMany(x => x.Employees)
                                    .HasForeignKey(x => x.BureauId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Finding

        builder.Entity<Finding>().ToTable("findingss");
        builder.Entity<Finding>().HasKey(x => x.Id);
        builder.Entity<Finding>().HasOne(x => x.Bureau)
                                    .WithMany(x => x.Findings)
                                    .HasForeignKey(x => x.BureauId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion


    }
}