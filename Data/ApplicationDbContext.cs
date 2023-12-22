using Microsoft.EntityFrameworkCore;
using MVC3.Models;

namespace MVC3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
        new Users { userId = 1, TypeOfUser = "Admin" },
        new Users { userId = 2, TypeOfUser = "Manager" },
        new Users { userId = 3, TypeOfUser = "Employee" }
    );

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Users)
                .WithMany(u => u.Employees)
                .HasForeignKey(e => e.UserId)  // Match with the property name
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Employee>().HasData(
                new Employee {IdEmployee=5, Email ="safi.moumen90@gmail.com", Password="123456", Name="momen",UserId = 1}
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
