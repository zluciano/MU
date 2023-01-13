using MagniUni.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagniUni.DAL
{
    public class CourseDAL
    {
        private MagniUniContext db = new MagniUniContext();

        public object GetAllCourses()
        {
            var courses = db.Courses.Select(c => new {
                id = c.ID,
                name = c.Name,
                students = c.Students.Select(s => s.FirstName + " " + s.LastName).ToList()
            }).ToList();
            return courses;
        }

        public object GetCourseById(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return null;
            }

            return new
            {
                id = course.ID,
                name = course.Name,
                students = course.Students.Select(s => s.FirstName + ' ' + s.LastName)
            };
        }

        public void CreateCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
        }

    }
}