using SMS.Domain.Entities;
using SMS.Infrastructure.Persistence; // Assuming this is where your DbContext is located
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SMS.Application.Interfaces;

namespace SMS.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext _context;

        public CourseRepository(SchoolDbContext context)
        {
            _context = context;
        }

        // Add a new course to the system
        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course); // Changed to AddAsync for async operations
            await _context.SaveChangesAsync();
        }

        // Retrieve a specific course based on its unique identifier
        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        // Retrieve all courses in the system
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        // Modify the details of an existing course
        public async Task UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        // Remove a course from the system
        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
    }
}
