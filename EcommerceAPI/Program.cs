
using Ecommerce.Core.IRepositories;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //connect  project to database
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));
            // tell the CLR that when he create a referance from IProductsRepository interface
            // //he must automaticly create obj from ProductsRepository and ref to it 
            builder.Services.AddScoped(typeof(IUnitOfWork<>),typeof(UnitOfWork<>));
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