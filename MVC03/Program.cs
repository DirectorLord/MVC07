using BLL.Services;
using DAL;
using DAL.Reporsitories;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MVC03;
public class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
        //builder.Services.AddScoped<IDepartmentRepository, DeparmentRepository>();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();

        builder.Services.AddDbContext<CompanyDBContext>(options =>
        {
            var _ = builder.Configuration["ConnectionsString:DefaultConnection"];
            options.UseSqlServer();
        });
        builder.Services.AddAutoMapper(typeof(AssemblyReference).Assembly);
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");

            app.UseHsts();


            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();


            app.Run();

        }
    }
}