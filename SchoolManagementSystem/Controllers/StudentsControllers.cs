using Microsoft.AspNetCore.Mvc;
using SMS.Application.Services;
using SMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    // Constructor: Dependency injection of IStudentService
    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // GET: api/students
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
    {
        // Call the service to get all students
        var students = await _studentService.GetAllStudentsAsync();
        return Ok(students); // Return the result as an HTTP 200 response
    }

    // GET: api/students/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudentById(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        if (student == null)
        {
            return NotFound(); // Return HTTP 404 if the student isn't found
        }
        return Ok(student);
    }

    // POST: api/students
    [HttpPost]
    public async Task<ActionResult> AddStudent(Student student)
    {
        await _studentService.AddStudentAsync(student);
        return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
    }

    // PUT: api/students/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStudent(int id, Student student)
    {
        if (id != student.Id)
        {
            return BadRequest(); // Return HTTP 400 if the IDs don't match
        }

        await _studentService.UpdateStudentAsync(student);
        return NoContent(); // Return HTTP 204 on success
    }

    // DELETE: api/students/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteStudent(int id)
    {
        await _studentService.DeleteStudentAsync(id);
        return NoContent();
    }
}
