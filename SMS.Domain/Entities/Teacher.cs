using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }

        // Navigation property to the courses the teacher is teaching
        public List<Course> Courses { get; set; } = new List<Course>();

        // Business logic: Assign a course to the teacher
        public void AssignCourse(Course course)
        {
            Courses.Add(course);
        }
    }
}
