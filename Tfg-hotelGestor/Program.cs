using Microsoft.EntityFrameworkCore;
using Tfg_hotelGestor.Contracts;
using Tfg_hotelGestor.Data;
using Tfg_hotelGestor.Services;
using AutoMapper;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped(typeof(IGenericCRUD<,>), typeof(CrudServiceBase<,>));
        builder.Services.AddAutoMapper(typeof(MappingProfile));



        builder.Services.AddDbContext<HotelGestorDbContext>(options =>
            options.UseMySql(
                builder.Configuration.GetConnectionString("default"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("default"))
            ));



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