
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo2.Data;
using WebApplicationDemo2.Repository.Implementation;
using WebApplicationDemo2.Repository.Interface;
using WebApplicationDemo2.Service.Implementation;
using WebApplicationDemo2.Service.Interface;

namespace WebApplicationDemo2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigurationManager Configuration = builder.Configuration;

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>(con => con.UseSqlServer(Configuration.GetConnectionString("DataContext")));
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));

            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}