using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task AddAsync(Course course); // Add a new course to the system 
        Task<Course> GetByIdAsync(int id); //Retrieve a specific course based on its unique identifier
        Task<IEnumerable<Course>> GetAllAsync(); // Retrieve all courses in the .system
        Task UpdateAsync(Course course); // Modify the details of an existing course
        Task DeleteAsync(int id);// Remove a course from the system
    }
}
