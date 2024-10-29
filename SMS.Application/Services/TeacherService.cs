using SMS.Application.Interfaces;
using SMS.Application.Services;
using SMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SMS.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }

        public async Task AddTeacherAsync(Teacher teacher)
        {
            // Business logic, e.g., validate the teacher's information
            await _teacherRepository.AddAsync(teacher);
        }

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            // Business logic, e.g., check if the teacher exists before updating
            var existingTeacher = await _teacherRepository.GetByIdAsync(teacher.Id);
            if (existingTeacher != null)
            {
                await _teacherRepository.UpdateAsync(teacher);
            }
            else
            {
                // Handle the case where the teacher doesn't exist
                // This could be logging, throwing an exception, etc.
            }
        }

        public async Task DeleteTeacherAsync(int id)
        {
            // Business logic, e.g., check if the teacher is involved in any courses
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher != null)
            {
                await _teacherRepository.DeleteAsync(id);
            }
            else
            {
                // Handle the case where the teacher doesn't exist
                // This could be logging, throwing an exception, etc.
            }
        }
    }
}
