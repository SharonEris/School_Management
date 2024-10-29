using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task AddAsync(Student student); // Add a new student to the system 
        Task<Student> GetByIdAsync(int id); //Retrieve a specific student based on its unique identifier
        Task<IEnumerable<Student>> GetAllAsync(); // Retrieve all students in the system
        Task UpdateAsync(Student student); // Modify the details of an existing student
        Task DeleteAsync(int id);// Remove a student from the system

        // Add this method to handle retrieval by email
        //Task<Student> GetByEmailAsync(string email);
    }
}
