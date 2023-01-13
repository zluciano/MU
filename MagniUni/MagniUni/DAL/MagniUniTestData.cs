using MagniUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniUni.DAL
{
    public class MagniUniTestData : System.Data.Entity.DropCreateDatabaseIfModelChanges<MagniUniContext>
    {
        protected override void Seed(MagniUniContext context)
        {
            var courses = new List<Course>
            {
                new Course{Name="Computer Engineering"},
                new Course{Name="Computer Science"},
                new Course{Name="Physics"}
            };

            var students = new List<Student>
            {
                new Student{CourseID=1,FirstName="Jose Luciano",LastName="de Morais Neto"},
                new Student{CourseID=2,FirstName="Donald",LastName="Knuth"},
                new Student{CourseID=3,FirstName="Werner",LastName="Heisenberg"},
                new Student{CourseID=3,FirstName="Pierre",LastName="Curie"},
            };

            var teachers = new List<Teacher>
            {
                new Teacher{FirstName="Albert",LastName="Eisntein"},
                new Teacher{FirstName="Terence",LastName="Tao"},
                new Teacher{FirstName="Marie",LastName="Curie"},
                new Teacher{FirstName="Alan",LastName="Turing"}
            };

            var disciplines = new List<Discipline>
            {
                new Discipline{TeacherID=1,Name="Physics"},
                new Discipline{TeacherID=2,Name="Math"},
                new Discipline{TeacherID=3,Name="Chemestry"},
                new Discipline{TeacherID=4,Name="Introduction to Cryptography"}
            };

            var enrollments = new List<Enrollment>
            {
                new Enrollment{StudentID=1,DisciplineID=1,Grade=10},
                new Enrollment{StudentID=1,DisciplineID=2,Grade=9.5},
                new Enrollment{StudentID=1,DisciplineID=3,Grade=8.5},
                new Enrollment{StudentID=1,DisciplineID=4,Grade=9.2},
                new Enrollment{StudentID=2,DisciplineID=1,Grade=10},
                new Enrollment{StudentID=2,DisciplineID=2,Grade=9.8},
                new Enrollment{StudentID=2,DisciplineID=3,Grade=8.7},
                new Enrollment{StudentID=3,DisciplineID=1,Grade=8.9},
                new Enrollment{StudentID=3,DisciplineID=2,Grade=8.1},
                new Enrollment{StudentID=3,DisciplineID=3,Grade=10},
                new Enrollment{StudentID=4,DisciplineID=2,Grade=9.7},
                new Enrollment{StudentID=4,DisciplineID=4,Grade=10}
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            teachers.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            disciplines.ForEach(s => context.Disciplines.Add(s));
            context.SaveChanges();

            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}