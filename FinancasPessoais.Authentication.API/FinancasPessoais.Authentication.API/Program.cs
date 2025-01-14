using FinancasPessoais.Authentication.API.Extensions;
using FinancasPessoais.Authentication.Infra.Data;
using FinancasPessoais.Authentication.Infra.Repository;
using FinancasPessoais.Authentication.Infra.Repository.UserRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FinancasPessoaisDbContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=FinancasPessoaisDB;User Id=sa;Password=P@ssw0rd;TrustServerCertificate=True"));

builder.AddDependencyInjectionExtension();
builder.AddAuthenticationExtension();

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
