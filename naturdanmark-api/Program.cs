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

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allowall", policy =>
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
}
);

var optionsbuilder = new DbContextOptionsBuilder<ObservationContext>();
optionsbuilder.UseSqlServer(Secret.secret);
ObservationContext obsdbcontext = new(optionsbuilder.Options);
builder.Services.AddSingleton<ObservationsRepoDB>(new ObservationsRepoDB(obsdbcontext));
var optionsbuilder2 = new DbContextOptionsBuilder<ImageContext>();
optionsbuilder2.UseSqlServer(Secret.secret);
ImageContext imgdbcontext = new(optionsbuilder2.Options);
builder.Services.AddSingleton<ObservationsRepoDB>(new ObservationsRepoDB(obsdbcontext));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("allowall");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
