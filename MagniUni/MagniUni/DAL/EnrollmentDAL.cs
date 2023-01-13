using MagniUni.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagniUni.DAL
{
    public class EnrollmentDAL
    {
        private MagniUniContext db = new MagniUniContext();

        public object GetAllEnrollments()
        {
            var enrollments = db.Enrollments.Select(e => new
            {
                studentId = e.StudentID,
                disciplineId = e.DisciplineID
            });

            return enrollments;
        }

        public object GetEnrollmentById(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return null;
            }

            return new
            {
                id = enrollment.ID,
                studentId = enrollment.StudentID,
                disciplineId = enrollment.DisciplineID,
                grade = enrollment.Grade
            };
        }

        public object GetEnrollmentByStudentIdAndDisciplineId(int studentId, int disciplineId)
        {
            var enrollment = db.Enrollments
                .Where(e => e.DisciplineID.Equals(disciplineId) && e.StudentID.Equals(studentId))
                .Select(e => new {
                    id = e.ID,
                    studentId = e.StudentID,
                    disciplineId = e.DisciplineID,
                    grade = e.Grade
                })
                .Single();
            if (enrollment == null)
            {
                return null;
            }

            return enrollment;
        }

        public void CreateEnrollment(Enrollment enrollment)
        {
            db.Enrollments.Add(enrollment);
            db.SaveChanges();
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            db.Entry(enrollment).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEnrollment(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
            db.SaveChanges();
        }
    }
}