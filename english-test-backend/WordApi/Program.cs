using Microsoft.EntityFrameworkCore;
using WordApi.Application;
using WordApi.Application.Interfaces;
using WordApi.Infrastructure;
using WordApi.Infrastructure.Repository;
using WordApi.Infrastructure.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));
builder.Services.AddScoped<IWordRepository, WordRepository>();
builder.Services.AddScoped<IWordService, WordService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
