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
    public class DisciplineController : Controller
    {
        private MagniUniContext db = new MagniUniContext();
        private DisciplineDAL disciplineDal = new DisciplineDAL();

        // GET: Discipline/AllDisciplines
        public ActionResult AllDisciplines()
        {
            var disciplines = disciplineDal.GetAllDisciplines();
            return Json(disciplines, JsonRequestBehavior.AllowGet);
        }

        // GET: Discipline/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var discipline = disciplineDal.GetDisciplineById(id.Value);
            if (discipline == null)
            {
                return HttpNotFound();
            }
            return Json(discipline, JsonRequestBehavior.AllowGet);
        }

        // POST: Discipline/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,TeacherID,Name")] Discipline discipline)
        {
            if (ModelState.IsValid)
            {
                disciplineDal.CreateDiscipline(discipline);
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Discipline/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,TeacherID,Name")] Discipline discipline)
        {
            if (ModelState.IsValid)
            {
                disciplineDal.UpdateDiscipline(discipline);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Discipline/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteDiscipline(int id)
        {
            disciplineDal.DeleteDiscipline(id);
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
