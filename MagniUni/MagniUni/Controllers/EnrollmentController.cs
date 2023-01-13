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
    public class EnrollmentController : Controller
    {
        private MagniUniContext db = new MagniUniContext();
        private EnrollmentDAL enrollmentDal = new EnrollmentDAL();

        // GET: Enrollment/AllEnrollments
        public ActionResult AllEnrollments()
        {
            var enrollments = enrollmentDal.GetAllEnrollments();
            return Json(enrollments, JsonRequestBehavior.AllowGet);
        }

        // Post: Enrollment/GetEnrollmentByStudentIdAndDisciplineId
        [HttpPost]
        public ActionResult EnrollmentByStudentIdAndDisciplineId(int[] ids)
        {
            var enrollments = enrollmentDal.GetEnrollmentByStudentIdAndDisciplineId(ids[0], ids[1]);
            return Json(enrollments, JsonRequestBehavior.AllowGet);
        }

        // GET: Enrollment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var enrollment = enrollmentDal.GetEnrollmentById(id.Value);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return Json(enrollment, JsonRequestBehavior.AllowGet);
        }

        // POST: Enrollment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,StudentID,DisciplineID,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                enrollmentDal.CreateEnrollment(enrollment);
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Enrollment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,StudentID,DisciplineID,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                enrollmentDal.UpdateEnrollment(enrollment);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            enrollmentDal.DeleteEnrollment(id);
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
