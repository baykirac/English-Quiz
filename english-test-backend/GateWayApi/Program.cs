using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();

var app = builder.Build();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("https://localhost:7050/swagger/v1/swagger.json", "Translation API");
    c.SwaggerEndpoint("https://localhost:7031/swagger/v1/swagger.json", "Word API");
    c.RoutePrefix = "swagger"; // URL: http://localhost:5000/swagger
});

await app.UseOcelot();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
