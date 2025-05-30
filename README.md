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

