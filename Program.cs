using EmployeeApi.Models;
using EmployeeApi.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddSingleton<MongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("MongoDBSettings:ConnectionString")));

builder.Services.AddScoped<EmployeeService>();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// GET employees
app.MapGet("/employees", async (EmployeeService employeeService) =>
    await employeeService.GetEmployees());

// POST create a new employee
app.MapPost("/employees", async (Employee employee, EmployeeService employeeService) =>
{
    var existingEmployee = await employeeService.GetEmployeeByEmail(employee.Email);
    if (existingEmployee != null)
    {
        return Results.BadRequest("Employee with the same email already exists.");
    }
    await employeeService.CreateEmployee(employee);
    return Results.Ok(employee);
});

// GET employee by ID
app.MapGet("/employees/{id}", async (string id, EmployeeService employeeService) =>
{
    var employee = await employeeService.GetEmployeeById(id);
    if (employee == null)
    {
        return Results.NotFound("Employee not found.");
    }
    return Results.Ok(employee);
});

app.Run();
