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
    public class TeacherController : Controller
    {
        private MagniUniContext db = new MagniUniContext();
        private TeacherDAL teacherDal = new TeacherDAL();

        // GET: Teacher/AllTeachers
        public ActionResult AllTeachers()
        {
            var teachers = teacherDal.GetAllTeachers();
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        // GET: Teacher/UnassignedTeachers
        public ActionResult UnassignedTeachers()
        {
            var teachers = teacherDal.GetUnassignedTeachers();
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var teacher = teacherDal.GetTeacherById(id.Value);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacherDal.CreateTeacher(teacher);
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacherDal.UpdateTeacher(teacher);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            teacherDal.DeleteTeacher(id);
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
