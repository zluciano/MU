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
    [AllowCrossOriginJson]
    public class CourseController : Controller
    {
        private MagniUniContext db = new MagniUniContext();
        private CourseDAL courseDal = new CourseDAL();

        // GET: Course/AllCourses
        public ActionResult AllCourses()
        {
            var courses = courseDal.GetAllCourses();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var course = courseDal.GetCourseById(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return Json(course, JsonRequestBehavior.AllowGet);
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Name")] Course course)
        {
            if (ModelState.IsValid)
            {
                courseDal.CreateCourse(course);

                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,Name")] Course course)
        {
            if (ModelState.IsValid)
            {
                courseDal.UpdateCourse(course);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            courseDal.DeleteCourse(id);
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
