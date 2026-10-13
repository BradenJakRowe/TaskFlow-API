# TaskFlow — Task Management API

TaskFlow is a task management REST API built with C# and ASP.NET Core. It allows users to create, retrieve, update and delete tasks, with support for due dates, priorities and task statuses.

## Features

- Create tasks with titles, descriptions, due dates and priorities.
- Retrieve all tasks or retrieve an individual task by ID.
- Update task details and statuses.
- Delete tasks.
- Represent task priorities and statuses using readable JSON enum values.
- Explore and test API endpoints using Swagger UI.

## Technologies

- **Language:** C#
- **Framework:** ASP.NET Core Minimal APIs
- **API Documentation:** Swagger / OpenAPI
- **Data Storage:** In-memory storage (currently)
- **Development Environment:** Visual Studio 2022
- **Version Control:** Git and GitHub

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/tasks` | Retrieve all tasks |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update a task |
| DELETE | `/api/tasks/{id}` | Delete a task |

## Prerequisites

- Visual Studio 2022
- .NET 8 SDK

## Running the Project

1. Clone the repository.
2. Open `Taskflow.Api.sln` in Visual Studio 2022.
3. Restore NuGet packages.
4. Run the `Taskflow.Api` project.
5. Open the Swagger UI address shown when the application starts.

## Current Limitations

Tasks are currently stored in memory and are lost when the application restarts.

## Planned Improvements

- Integrate SQL Server using Entity Framework Core.
- Add input validation and consistent error handling.
- Implement automated unit and integration tests.
- Develop a user interface for managing tasks.
