using Bookstore.Context;
using Bookstore.DTOs.Mapping;
using Bookstore.Repositories;
using Bookstore.Services;
using Bookstore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().
    AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => 
                   options.UseMySql(mySqlConnection,
                        ServerVersion.AutoDetect(mySqlConnection)));


builder.Services.AddScoped<IGenreRepository,GenreRepository>();
builder.Services.AddScoped<IBookRepository,BookRepository>();
builder.Services.AddScoped<IGenreService,GenreService>();
builder.Services.AddScoped<IBookService,BookService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

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
