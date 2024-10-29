using Microsoft.AspNetCore.Mvc;
using SMS.Application.Services;
using SMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        // Constructor: Dependency injection of ITeacherService
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // GET: api/teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers); // Return the result as an HTTP 200 response
        }

        // GET: api/teacher/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null)
            {
                return NotFound(); // Return HTTP 404 if the teacher isn't found
            }
            return Ok(teacher);
        }

        // POST: api/teacher
        [HttpPost]
        public async Task<ActionResult> AddTeacher(Teacher teacher)
        {
            await _teacherService.AddTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }

        // PUT: api/teacher/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest(); // Return HTTP 400 if the IDs don't match
            }

            await _teacherService.UpdateTeacherAsync(teacher);
            return NoContent(); // Return HTTP 204 on success
        }

        // DELETE: api/teacher/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            await _teacherService.DeleteTeacherAsync(id);
            return NoContent();
        }
    }
}
