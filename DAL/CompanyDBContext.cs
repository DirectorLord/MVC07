using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL;

public class CompanyDBContext(DbContextOptions<CompanyDBContext> options) : DbContext(options)
{
    public DbSet<Department> Department { get; set; }
    public DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

