using KopiShop.Repository;
using KopiShop.Service;

namespace KopiShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //PENDAFTARAN DEPENDENCY INJECTION
            builder.Services.AddScoped<IKopiRepository, KopiRepository>();
            builder.Services.AddScoped<IKopiService, KopiService>();
            //builder.Services.AddScoped<IKopiRepository, KopiRepository>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //Configure the HTTP request pipeline.
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