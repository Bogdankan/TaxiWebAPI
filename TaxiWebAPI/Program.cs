using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MvcMovie.Models;
using TaxiWebAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaxiWebAPIContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaxiWebAPIContext") ?? throw new InvalidOperationException("Connection string 'TaxiWebAPIContext' not found."));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
     

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
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
