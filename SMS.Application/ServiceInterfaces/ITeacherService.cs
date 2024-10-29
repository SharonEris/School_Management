using SMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Application.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task AddTeacherAsync(Teacher Teacher);
        Task UpdateTeacherAsync(Teacher Teacher);
        Task DeleteTeacherAsync(int id);
    }
}
