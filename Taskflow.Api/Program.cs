using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Taskflow.Api.Data;
using Taskflow.Api.Models;
using Taskflow.Api.Services;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TaskService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(
        new JsonStringEnumConverter());
});

builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
 

//API CRUD functionality
app.MapGet("/", () => "Welcome to Taskflow API"); 

//RETRIEVE all tasks by referencing the service method GetAll() 
app.MapGet("/api/tasks", async (TaskService service) =>

{
    var task = await service.GetAllAsync();

    return Results.Ok(task);
});


//RETRIEVE a task by referencing the GetById() method and using the id property
app.MapGet("/api/tasks/{id:int}", async (
    int id,
    TaskService service) =>
    {
        var task = await service.GetByIdAsync(id);

        if (task is null)
            return Results.NotFound();

        return Results.Ok(task);
    });


//CREATE a task, referencing the Create method from the Service class
app.MapPost("/api/tasks", async (TaskItem task, TaskService service) =>
{
    if (string.IsNullOrEmpty(task.Title))
        {
            return Results.BadRequest("Task Title is required.");
        }

    var createdTask = await service.CreateAsync(task);
    return Results.Created($"/api/tasks/{createdTask.Id}", createdTask);
});

//UPDATE a task, referencing the Update method from the Service class

app.MapPut("/api/tasks/{id:int}", async (
    int id,
    TaskItem task,
    TaskService service) =>
{
    var updated = await service.UpdateAsync(id, task);


    if (!updated)
       return Results.NotFound();
    
    return Results.NoContent();
});


//DELETE the task from the application .
app.MapDelete("/api/tasks/{id:int}", async (
    int id,
    TaskService service) =>
{
    var deleted = await service.DeleteAsync(id);


    if (!deleted)
       return Results.NotFound();
    
    return Results.NoContent();
});

app.Run();


