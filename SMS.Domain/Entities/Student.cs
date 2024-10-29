using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        // Navigation property to the courses the student is enrolled in
        public List<Course> Courses { get; set; } = new List<Course>();

        // Business logic: Enroll a student in a course
        public void EnrollInCourse(Course course)
        {
            // Add the course to the student's list of courses
            Courses.Add(course);
        }
    }
}
