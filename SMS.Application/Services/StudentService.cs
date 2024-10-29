using SMS.Application.Interfaces;
using SMS.Application.Services;
using SMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository; // Dependency Injection Field

        // Constructor
        public StudentService(IStudentRepository studentRepository) // Dependency Injection via Constructor
        {
            _studentRepository = studentRepository; // Dependency Injection Occurs Here
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task AddStudentAsync(Student student)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(student.Id); // Use appropriate method if you have GetByEmailAsync
            if (existingStudent != null)
            {
                throw new InvalidOperationException("A student with this ID already exists.");
            }
            await _studentRepository.AddAsync(student);
        }


        public async Task UpdateStudentAsync(Student student)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(student.Id);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException("The student does not exist.");
            }
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                throw new KeyNotFoundException("The student does not exist.");
            }
            await _studentRepository.DeleteAsync(id);
        }
    }
}
