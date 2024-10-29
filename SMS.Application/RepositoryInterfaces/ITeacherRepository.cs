using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Interfaces
{
    public interface ITeacherRepository
    {
        Task AddAsync(Teacher teacher); // Add a new teacher to the system 
        Task<Teacher> GetByIdAsync(int id); //Retrieve a specific teacher based on its unique identifier
        Task<IEnumerable<Teacher>> GetAllAsync(); // Retrieve all teachers in the .system
        Task UpdateAsync(Teacher teacher); // Modify the details of an existing teacher
        Task DeleteAsync(int id);// Remove a teacher from the system
    }
}
