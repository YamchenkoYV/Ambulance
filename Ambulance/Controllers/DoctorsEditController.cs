using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ambulance.Controllers
{
    public class DoctorsEditController : Controller
    {
        private ambulanceEntities db = new ambulanceEntities();

        //
        // GET: /DoctorsEdit/

        public ActionResult Index()
        {
            return View(db.doctors.ToList());
        }

        //
        // GET: /DoctorsEdit/Details/5

        public ActionResult Details(long id = 0)
        {
            doctors doctors = db.doctors.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        //
        // GET: /DoctorsEdit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DoctorsEdit/Create

        [HttpPost]
        public ActionResult Create(doctors doctors)
        {
            if (ModelState.IsValid)
            {
                db.doctors.Add(doctors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctors);
        }

        //
        // GET: /DoctorsEdit/Edit/5

        public ActionResult Edit(long id = 0)
        {
            doctors doctors = db.doctors.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        //
        // POST: /DoctorsEdit/Edit/5

        [HttpPost]
        public ActionResult Edit(doctors doctors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctors);
        }

        //
        // GET: /DoctorsEdit/Delete/5

        public ActionResult Delete(long id = 0)
        {
            doctors doctors = db.doctors.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        //
        // POST: /DoctorsEdit/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            doctors doctors = db.doctors.Find(id);
            db.doctors.Remove(doctors);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}