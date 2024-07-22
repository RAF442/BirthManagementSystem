using BirthManagementSystem.Infrastructure;
using BirthManagementSystem.Application;
using BirthManagementSystem.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UsePresentation();

app.Run();
