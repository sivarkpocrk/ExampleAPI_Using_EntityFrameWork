using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using CustomApi.Data; // Adjust according to your actual namespace
using CustomApi.Models; // Adjust according to your actual namespace
using CustomApi.Validators; // Ensure this matches where your ProductValidator is located
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

//builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();  // Ensure HTTPS redirection is used in production
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
