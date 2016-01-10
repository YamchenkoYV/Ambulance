using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ambulance.Controllers
{
    [Authorize(Roles = "admin")]
    public class HistoryController : Controller
    {
        private ambulanceEntities db = new ambulanceEntities();

        //
        // GET: /History/

        public ActionResult Index()
        {
            var ill_history = db.ill_history.Include(i => i.doctors).Include(i => i.palata);
            return View(ill_history.ToList());
        }

        //
        // GET: /History/Details/5

        public ActionResult Details(long id = 0)
        {
            ill_history ill_history = db.ill_history.Find(id);
            if (ill_history == null)
            {
                return HttpNotFound();
            }
            return View(ill_history);
        }

        //
        // GET: /History/Create

        public ActionResult Create()
        {
            ViewBag.shifr = new SelectList(db.doctors, "shifr", "d_name");
            ViewBag.Pal_id = new SelectList(db.palata, "Pal_id", "Pal_id");
            return View();
        }

        //
        // POST: /History/Create

        [HttpPost]
        public ActionResult Create(ill_history ill_history)
        {
            if (ModelState.IsValid)
            {
                db.ill_history.Add(ill_history);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.shifr = new SelectList(db.doctors, "shifr", "d_name", ill_history.shifr);
            ViewBag.Pal_id = new SelectList(db.palata, "Pal_id", "Pal_id", ill_history.Pal_id);
            return View(ill_history);
        }

        //
        // GET: /History/Edit/5

        public ActionResult Edit(long id = 0)
        {
            ill_history ill_history = db.ill_history.Find(id);
            if (ill_history == null)
            {
                return HttpNotFound();
            }
            ViewBag.shifr = new SelectList(db.doctors, "shifr", "d_name", ill_history.shifr);
            ViewBag.Pal_id = new SelectList(db.palata, "Pal_id", "Pal_id", ill_history.Pal_id);
            return View(ill_history);
        }

        //
        // POST: /History/Edit/5

        [HttpPost]
        public ActionResult Edit(ill_history ill_history)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ill_history).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.shifr = new SelectList(db.doctors, "shifr", "d_name", ill_history.shifr);
            ViewBag.Pal_id = new SelectList(db.palata, "Pal_id", "Pal_id", ill_history.Pal_id);
            return View(ill_history);
        }

        //
        // GET: /History/Delete/5

        public ActionResult Delete(long id = 0)
        {
            ill_history ill_history = db.ill_history.Find(id);
            if (ill_history == null)
            {
                return HttpNotFound();
            }
            return View(ill_history);
        }

        //
        // POST: /History/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            ill_history ill_history = db.ill_history.Find(id);
            db.ill_history.Remove(ill_history);
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