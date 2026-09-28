using eCommecre.Infrastructre.DbContexts;
using eCommecre.Infrastructre.Repositories;
using eCommecre.Infrastructre.Repository_Interfaces;
using eCommerce.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using eCommerce.API.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using eCommerce.API.DTOs;
using eCommerce.API.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// CORS - allow Angular frontend
var angularOrigin = "http://localhost:4200";
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevClient", policy =>
    {
        policy.WithOrigins(angularOrigin)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Products Service API",
        Version = "v1"
    });
});

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<FluentValidation.IValidator<ProductAddRequest>, ProductAddRequestValidator>();
builder.Services.AddScoped<FluentValidation.IValidator<ProductUpdateRequest>, ProductUpdateRequestValidator>();

var serverVersion = new MySqlServerVersion(new Version(8, 0, 46));
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions => dbContextOptions.UseMySql(connStr, serverVersion));
builder.Services.AddScoped<ProductsService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Global exception handler - register early in pipeline to catch all exceptions
app.UseCustomExceptionHandler();

// Serve Swagger UI at the app root so Swagger is the homepage.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Enable CORS for Angular dev client
app.UseCors("AllowAngularDevClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
