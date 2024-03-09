
using Microsoft.Extensions.Configuration;
using StubbedContextLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Entities;
using DTOToEntity;
using DTO;
using System;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IService<GroupDTO>,GroupService>();
builder.Services.AddScoped<IService<LangueDTO>,LangueService>();
builder.Services.AddScoped<IService<RoleDTO>,RoleService>();
builder.Services.AddScoped<IService<TranslateDTO>,TranslateService>();
builder.Services.AddScoped<IService<UserDTO>, UserService>();
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
