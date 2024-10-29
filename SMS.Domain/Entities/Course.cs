using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        // Navigation property to the students enrolled in the course
        public List<Student> Students { get; set; } = new List<Student>();

        // Business logic: Add a student to the course
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
    }
}
