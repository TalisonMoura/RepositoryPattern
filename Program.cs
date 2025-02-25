using Microsoft.OpenApi.Models;
using RepositoryPatternUoW.Data;
using Microsoft.EntityFrameworkCore;

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

        builder.Services.AddDbContext<ApplicationContext>(p => p
                        .UseSqlServer("Server=TALISONJM\\SQLEXPRESS;Database=RepositoryPatternUoW;Integrated Security=true;TrustServerCertificate=True;pooling=true"));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EFCore.RepositoryPatternUoW v1"));
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}