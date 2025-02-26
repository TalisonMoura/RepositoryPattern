using Microsoft.OpenApi.Models;
using RepositoryPatternUoW.Data;
using RepositoryPatternUoW.Domain;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternUoW.Data.Repositories;
using RepositoryPatternUoW.Data.Repositories.Base;
using RepositoryPatternUoW.Data.Repositories.Interfaces;
using RepositoryPatternUoW.Data.Repositories.Base.Interfaces;

namespace RepositoryPatternUoW;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "EFCore.RepositoryPatternUoW", Version = "v1" });
        });


        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        builder.Services.AddDbContext<ApplicationContext>(p => p
                        .UseSqlServer("Server=TALISONJM\\SQLEXPRESS;Database=RepositoryPatternUoW;Integrated Security=true;TrustServerCertificate=True;pooling=true"));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EFCore.RepositoryPatternUoW v1"));
        }

        //InitializeSeed(app);

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void InitializeSeed(IApplicationBuilder app)
    {
        using var database = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationContext>();

        if (database.Database.EnsureCreated())
        {
            database.Departments.AddRange(Enumerable.Range(1, 10).Select(d => new Department
            {
                Description = $"Department - {d}",
                Employees = Enumerable.Range(1, 10).Select(e => new Employee
                {
                    Name = $"Employee: {e}/{d}"
                }).ToList()
            }));

            database.SaveChanges();
        }
    }
}