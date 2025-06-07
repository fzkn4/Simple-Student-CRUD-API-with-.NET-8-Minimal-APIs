# 📚 Simple Student CRUD API with .NET 8 Minimal APIs

Welcome to a beginner-friendly tutorial on building a **CRUD (Create, Read, Update, Delete)** API using **.NET 8 Minimal APIs**. This project focuses on clarity and simplicity, ideal for those new to web API development with .NET.

---

## 🚀 Getting Started

Follow the steps below to get the project running on your local machine.

### 🔧 Prerequisites

Make sure the following are installed:

- **[.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)**  
  Includes the runtime and CLI tools.
- **[Visual Studio Code](https://code.visualstudio.com/)**  
  A lightweight, extensible code editor.
- **C# Dev Kit Extension**  
  Provides IntelliSense and C# development features in VS Code.
- **REST Client Extension**  
  Enables you to send HTTP requests directly from `.http` files.

---

## 📥 Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/fzkn4/Simple-Student-CRUD-API-with-.NET-8-Minimal-APIs.git
   ```
2. **Navigate to the Project folder**
   ```bash
   cd simple-CRUD-API-with-.NET/MyMinimalApi
   ```
3. **Restore dependencies**
   ```bash
   dotnet restore
   ```
---

## ▶️ Running the API
Once you've installed the prerequisites and cloned the repo, you can run the API:
```bash
dotnet watch
```
**This will:**

- Build and run the application.

- Launch the API on http://localhost:5000 (or another available port).

- Enable hot-reload for real-time code changes.

You'll see the running address in the terminal.

---

## 📡 API Endpoints
This API exposes the following endpoints to manage student data:
**🧾 Student Record Structure**
```csharp
internal record student(int edp, string name, int year, string course);
```
| Field    | Type   | Description                                        |
| -------- | ------ | -------------------------------------------------- |
| `edp`    | int    | Unique student identifier (Education/Dept Program) |
| `name`   | string | Full name of the student                           |
| `year`   | int    | Current year level                                 |
| `course` | string | Course code (e.g., `"BSCS"`)                       |

---

**📘 Get All Students**
- URL: GET /students
- Description: Returns a list of all registered students.
- Response: 200 OK

---

**📙 Get Student by EDP**
- URL: GET /students/{edp}
- Description: Fetch a specific student using their EDP.
- Response:
  - 200 OK – Student found
  - 404 Not Found – No matching student

---
**📗 Create New Student**
- URL: POST /students
- Description: Add a new student to the list.
- Request Body (JSON):
  ```json
    {
  "edp": 1005,
  "name": "Benito S. Ambot",
  "year": 1,
  "course": "BSCE"
  }
  ```
- Response:
  - 201 Created – Student added successfully
  - 409 Conflict – EDP already exists

---
**📕 Delete Student**
- URL: DELETE /students/{edp}
- Description: Remove a student using their EDP.
- Response:
  - 204 No Content – Deletion successful
  - 404 Not Found – Student does not exist

---
**🧪 API Testing (with .http file)**
Use the REST Client extension in VS Code to send requests directly.
> 📄 File: `students.http`
```http
### Get root endpoint (all students)
GET http://localhost:5154/

### Get specific student by EDP
GET http://localhost:5154/students/1005

### Create new student
POST http://localhost:5154/students
Content-Type: application/json

{
    "edp": 1005,
    "name": "Benito S. Ambot",
    "year": 1,
    "course": "BSCE"
}

### Get all students
GET http://localhost:5154/students

### Delete a student
DELETE http://localhost:5154/students/1005
```
> 🛠 Make sure your port matches the one from `dotnet watch`. Update `5154` if needed.
---
## 👩‍💻 Project Structure
The core logic for this Minimal API resides in a single `Program.cs` file for simplicity.
**`Program.cs`**:
  - Sets up the web application (`WebApplication.CreateBuilder`, `app.Build`).
  - Defines the in-memory `List<student>` for data storage.
  - Configures Swagger/OpenAPI for API documentation and testing.
  - Maps all the API endpoints (`app.MapGet`, `app.MapPost`, `app.MapDelete`).
  - Defines the `student` record.

---
## 🤝 Contribution
Feel free to fork this repository, experiment, and suggest improvements! This project is intended as a learning tool.
