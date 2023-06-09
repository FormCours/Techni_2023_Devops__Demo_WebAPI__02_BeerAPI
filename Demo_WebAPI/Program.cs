using Demo_WebAPI.BLL.Interfaces;
using Demo_WebAPI.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// -> Configuration de l'injection de service
builder.Services.AddScoped<IBeerService, BeerService>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
