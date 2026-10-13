# Taskflow

Taskflow is a task management application designed to help users organise their workload, manage tasks, and track their progress.

This is a portfolio project to demonstrate my abilities in development using C#, RESTful API development, OO programming, and database integration in the software development process.

## Features

- Create new tasks
- View and retrieve tasks
- Update tasks and completion status
- Delete tasks
- Organise and manage tasks through the RESTful API

## Technologies
- Language: C#
- Framework: ASP.NET Core Web API
- Database: SQL Server
- Data Access: Entity Framework Core
- Version Control: GitHub

## Project Status
- Currently in development

## Prerequisites
- Visual Studio 2022
- .NET 8.0 SDK

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/tasks` | Retrieve all tasks |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update a task |
| DELETE | `/api/tasks/{id}` | Delete a task |
