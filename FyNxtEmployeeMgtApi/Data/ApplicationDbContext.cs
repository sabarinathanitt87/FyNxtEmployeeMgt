using FyNxtEmployeeMgtApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace FyNxtEmployeeMgtApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }
        public DbSet<EmployeeKPI> EmployeeKPI { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<EmployeeKPI>(builder =>
            {
                builder.HasNoKey();
                builder.ToTable("EmployeeKPI");
            });
            base.OnModelCreating(modelBuilder);

        }
    }
}
