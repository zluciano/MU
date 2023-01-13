using MagniUni.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagniUni.DAL
{
    public class TeacherDAL
    {
        private MagniUniContext db = new MagniUniContext();

        public object GetAllTeachers()
        {
            var teachers = db.Teachers.Select(t => new
            {
                id = t.ID,
                firstName = t.FirstName,
                lastName = t.LastName,
                birthday = t.Birthday,
                salary = t.Salary
            });

            return teachers;
        }

        public object GetUnassignedTeachers()
        {
            var assingedTeachers = db.Disciplines.Select(d => d.TeacherID).ToList();
            var teachers = db.Teachers
                .Where(t => !assingedTeachers.Contains(t.ID))
                .Select(t => new
            {
                id = t.ID,
                firstName = t.FirstName,
                lastName = t.LastName,
                birthday = t.Birthday,
                salary = t.Salary
            });

            return teachers;
        }

        public object GetTeacherById(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return null;
            }

            return new
            {
                id = teacher.ID,
                firstName = teacher.FirstName,
                lastName = teacher.LastName,
                birthday = teacher.Birthday,
                salary = teacher.Salary
            };
        }

        public void CreateTeacher(Teacher teacher)
        {
            db.Teachers.Add(teacher);
            db.SaveChanges();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            db.Entry(teacher).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteTeacher(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
        }
    }
}