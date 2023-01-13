using MagniUni.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagniUni.DAL
{
    public class StudentDAL
    {
        private MagniUniContext db = new MagniUniContext();

        public object GetAllStudents()
        {
            var students = db.Students
                .Include(s => s.Course)
                .Select(s => new {
                    id = s.ID,
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    birthday = s.Birthday,
                    course = new
                    {
                        id = s.CourseID,
                        name = s.Course.Name
                    },
                    disciplines = s.Enrollments.Select(e => e.Discipline.Name).ToList()
                });

            return students.ToList();
        }

        public object GetStudentById(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return null;
            }

            return new
            {
                id = student.ID,
                firstName = student.FirstName,
                lastName = student.LastName,
                birthday = student.Birthday,
                course = new {
                id = student.CourseID,
                name = student.Course.Name},
                disciplines = student.Enrollments.Select(e => e.Discipline.Name).ToList()
            };
        }

        public void CreateStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
        }

    }
}