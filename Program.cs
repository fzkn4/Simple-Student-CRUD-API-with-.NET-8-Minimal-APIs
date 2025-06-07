var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<student> students = new List<student>();

students.Add(new student(1, "ezio", 4, "BSCS"));
students.Add(new student(2, "fzkn4", 4, "BSCS"));
students.Add(new student(3, "auditore", 4, "BSCS"));

app.MapGet("/", () => students);

// retrieving all students info
app.MapGet("/students", () => students);

// creating students
app.MapPost("/students", (student newStudent) =>
{
    if (students.Any(s => s.edp == newStudent.edp))
    {
        return Results.Conflict($"Student with EDP {newStudent.edp} already exist");
    }
    students.Add(newStudent);

    return Results.Created($"/students/{newStudent.edp}", newStudent);
});

// retrieving student information
app.MapGet("/students/{edp}", (int edp) =>
{
    var student = students.FirstOrDefault(s => s.edp == edp);
    if (student == null)
    {
        return Results.NotFound($"No registered student of this EDP: {edp}");
    }
    return Results.Ok(student);
});

// deleting student 
app.MapDelete("/students/{edp}", (int edp) =>
{
    var student = students.FirstOrDefault(s => s.edp == edp);
    if (student == null)
    {
        return Results.NotFound($"No registered student with this EDP: {edp}");
    }
    students.Remove(student);
    return Results.NoContent();
});

app.Run();

internal record student(int edp, string name, int year, string course);