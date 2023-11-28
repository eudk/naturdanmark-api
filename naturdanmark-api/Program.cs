using Microsoft.EntityFrameworkCore;
using naturdanmark_api.Context;
using naturdanmark_api.Repositories;
using naturdanmark_api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var optionsbuilder = new DbContextOptionsBuilder<ObservationContext>();
optionsbuilder.UseSqlServer(Secret.secret);
ObservationContext dbcontext = new(optionsbuilder.Options);
builder.Services.AddSingleton<ObservationsRepoDB>(new ObservationsRepoDB(dbcontext));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
