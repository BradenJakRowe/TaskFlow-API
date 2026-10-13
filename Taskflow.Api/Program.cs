using Taskflow.Api.Models;
using Taskflow.Api.Services;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TaskService>();

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
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
 

//API CRUD functionality
app.MapGet("/", () => "Welcome to Taskflow API"); 

//RETRIEVE all tasks by referencing the service method GetAll() 
app.MapGet("/api/tasks", (TaskService service) =>

{
    return Results.Ok(service.GetAll());
});


//RETRIEVE a task by referencing the GetById() method and using the id property
app.MapGet("/api/tasks/{id:int}", (
    int id,
    TaskService service) =>
    {
        var task = service.GetById(id);

        return task is null
            ?Results.NotFound()
            :Results.Ok(task);

    });


//CREATE a task, referencing the Create method from the Service class
app.MapPost("/api/tasks", (TaskItem task, TaskService service) =>
{
    if (string.IsNullOrEmpty(task.Title))
        {
            return Results.BadRequest("Task Title is required.");
        }

    var createdTask = service.Create(task);
    return Results.Created($"/api/tasks/{createdTask.Id}", createdTask);
});

//UPDATE a task, referencing the Update method from the Service class

app.MapPut("/api/tasks/{id:int}", (
    int id,
    TaskItem task,
    TaskService service) =>
{
    return service.Update(id, task)
        ? Results.NoContent()
        : Results.NotFound();
});


//DELETE the task from the application .
app.MapDelete("/api/tasks/{id:int}", (
    int id,
    TaskService service) =>
{
    return service.Delete(id)
        ? Results.NoContent()
        : Results.NotFound();
});

app.Run();


