using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagniUni.DAL;
using MagniUni.Models;

namespace MagniUni.Controllers
{
    public class StudentController : Controller
    {
        private MagniUniContext db = new MagniUniContext();

        private StudentDAL studentDal = new StudentDAL();

        public JsonResult AllStudents()
        {
            var students = studentDal.GetAllStudents();
            return Json(students, JsonRequestBehavior.AllowGet);
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = studentDal.GetStudentById(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,CourseID,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentDal.CreateStudent(student);
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,CourseID,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentDal.UpdateStudent(student);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            studentDal.DeleteStudent(id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
