using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using OrdersBack.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// builder.Services.AddDbContext<BdatosContext>(opt => opt.UseSqlServer("Server=localhost;Database=BDATOS;Trusted_Connection=true;TrustServerCertificate=True;"));
builder.Services.AddDbContext<BdatosContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("bDatos")));

// HttpClient
builder.Services.AddHttpClient();
// Registrar acceso a la configuraci�n de ApiSettings
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

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

public class ApiSettings
{
    public string SunatApiKey { get; set; }
}