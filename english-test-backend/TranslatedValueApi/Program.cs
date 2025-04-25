using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TranslatedValueApi.Application;
using TranslatedValueApi.Application.Interfaces;
using TranslatedValueApi.Infrastructure;
using TranslatedValueApi.Infrastructure.Repository;
using TranslatedValueApi.Infrastructure.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));
builder.Services.AddScoped<ITranslatedValueRepository, TranslatedValueRepository>();
builder.Services.AddScoped<ITranslationService, TranslationService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
