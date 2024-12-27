using AdvanceDataAccessAssignment.Data;
using AdvanceDataAccessAssignment.Interface;
using AdvanceDataAccessAssignment.Repositories;
using AdvanceDataAccessAssignment.Services;
using Microsoft.EntityFrameworkCore;

namespace AdvanceDataAccessAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IElectronicsService,ElectronicsService>();
            builder.Services.AddScoped<ILinqDataService, LinqDataService>();
            builder.Services.AddDbContext<AdvanceDataAccessAssignmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                return new ElectronicsRepository(connectionString);
            });            builder.Services.AddScoped(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                return new LinqDataRepository(connectionString);
            });
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {               
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseStaticFiles();         

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                options.RoutePrefix = "swagger"; 
            });
            app.UseRouting();

            app.UseAuthorization();

            app.Run();
        }
    }
}
