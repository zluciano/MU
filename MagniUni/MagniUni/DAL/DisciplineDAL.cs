using MagniUni.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagniUni.DAL
{
    public class DisciplineDAL
    {
        private MagniUniContext db = new MagniUniContext();

        public object GetAllDisciplines()
        {
            var disciplines = db.Disciplines
                .Select(d => new
                {
                    id = d.ID,
                    name = d.Name,
                    teacherId = d.Teacher.ID,
                    students = d.Enrollments.Select(e => new {
                    id = e.Student.ID,
                    firstName = e.Student.FirstName,
                    lastName = e.Student.LastName}).ToList()
                }).ToList();

            return disciplines;
        }

        public object GetDisciplineById(int id)
        {
            Discipline discipline = db.Disciplines.Find(id);
            if (discipline == null)
            {
                return null;
            }

            return new
            {
                id = discipline.ID,
                name = discipline.Name,
                teacher = discipline.Teacher.ID,
                students = discipline.Enrollments.Select(e => new {
                    id = e.Student.ID,
                    firstName = e.Student.FirstName,
                    lastName = e.Student.LastName
                }).ToList()
            };
        }

        public void CreateDiscipline(Discipline discipline)
        {
            db.Disciplines.Add(discipline);
            db.SaveChanges();
        }

        public void UpdateDiscipline(Discipline discipline)
        {
            db.Entry(discipline).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteDiscipline(int id)
        {
            Discipline discipline = db.Disciplines.Find(id);
            db.Disciplines.Remove(discipline);
            db.SaveChanges();
        }

    }
}