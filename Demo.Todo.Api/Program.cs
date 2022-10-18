using Demo.Todo.Infrastructure;
using Demo.Todo.Application;
using Demo.Todo.Application.Common.Interfaces;
using Demo.Todo.Domain;
using Demo.Todo.Application.Todo.Dtos;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/todos/{status}", async (ITodoService todoService, TodoStatus status) =>
{
    return await todoService.GetTodosAsync(status);
})
.WithName("GetNewTodos");

app.MapPost("/todos", async (ITodoService todoService, [FromBody]CreateTodoDto dto) =>
{
    return await todoService.CreateTodoAsync(dto);
})
.WithName("CreateNewTodo");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}