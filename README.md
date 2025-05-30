Task Management System - MOJTask
This is a Task Management System where users can create, view, update, and delete tasks. The system includes both frontend (MVC) and backend API for managing tasks with fields such as title, description, status, and due date.

Project Overview

The system is built using ASP.NET Core MVC for the frontend and Entity Framework Core with SQLite for database management. It supports both CRUD operations (Create, Read, Update, Delete) for managing tasks. The system includes validation, error handling, and API endpoints for handling task management.

Features
•	Create a task with:

  -Title
  
  -Description (optional)
  
  -Status (Pending, InProgress, Done)
  
  -Due Date/Time
  
•	View task details

•	Update task status

•	Delete a task

•	Task data is seeded into the database for initial testing.

•	Alert Notifications: The application provides alert notifications for success and failure scenarios (e.g., task creation, update, deletion).

________________________________________
Technologies Used

•	Backend: ASP.NET Core MVC

•	Database: SQLite

•	Validation: Data Annotations for server-side validation

•	Client-side Validation: jQuery Validate
•	API: RESTful API built with ASP.NET Core
•	Alerts: JavaScript alerts for success and error notifications

API Endpoints

1. Create Task
POST /api/tasks

Request body:

json


{

  "title": "Task Title",
  
  "description": "Task Description",
  
  "status": "Pending",
  
  "dueDate": "2025-06-01T10:00:00"
  
}

Response:

Status: 201 Created

Returns the created task's data, including the task ID.

2. Get All Tasks
   
GET /api/tasks

Response:

json
[
  {
  
    "id": 1,
    
    "title": "Task 1",
    
    "description": "Description of task 1",
    
    "status": "Pending",
    
    "dueDate": "2025-06-01T10:00:00"
    
  },
  
  {
  
    "id": 2,
    
    "title": "Task 2",
    
    "description": "Description of task 2",
    
    "status": "InProgress",
    
    "dueDate": "2025-06-02T12:00:00"
    
  }
  
]

3. Get Task by ID
   
GET /api/tasks/{id}

Parameters: id (task ID)

Response:

json

{

  "id": 1,
  
  "title": "Task 1",
  
  "description": "Description of task 1",
  
  "status": "Pending",
  
  "dueDate": "2025-06-01T10:00:00"
  
}

4. Update Task Status
   
PUT /api/tasks/{id}

Parameters: id (task ID)

Request body:

json

{

  "status": "Done"
  
}

Response:


Status: 200 OK

Returns the updated task.

5. Delete Task
   
DELETE /api/tasks/{id}

Parameters: id (task ID)

Response:

Status: 204 No Content

The task is deleted successfully.

Frontend Views (MVC)

1. Create Task:
   
A form where the user can create a new task by entering a title, description, status, and due date.

URL: /Tasks/Create

POST method submits the task.

2. Edit Task:
   
A form to edit an existing task's details including title, description, status, and due date.

URL: /Tasks/Edit/{id}

POST method submits the edited task.

3. Delete Task:
   
A confirmation page asking the user to confirm deletion of a task.

URL: /Tasks/Delete/{id}

POST method confirms the deletion.

4. View Task Details:

Displays the task details including the title, description, status, and due date.

URL: /Tasks/Details/{id}

GET method to view the task.
