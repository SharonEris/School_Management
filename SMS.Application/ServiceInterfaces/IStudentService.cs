using SMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Application.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Student Student);
        Task UpdateStudentAsync(Student Student);
        Task DeleteStudentAsync(int id);
    }
}
