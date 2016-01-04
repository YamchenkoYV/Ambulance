using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ambulance.Controllers
{
    public class MsisterController : Controller
    {
        private ambulanceEntities db = new ambulanceEntities();

        //
        // GET: /Msister/

        public ActionResult Index()
        {
            return View(db.m_sister.ToList());
        }

        //
        // GET: /Msister/Details/5

        public ActionResult Details(long id = 0)
        {
            m_sister m_sister = db.m_sister.Find(id);
            if (m_sister == null)
            {
                return HttpNotFound();
            }
            return View(m_sister);
        }

        //
        // GET: /Msister/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Msister/Create

        [HttpPost]
        public ActionResult Create(m_sister m_sister)
        {
            if (ModelState.IsValid)
            {
                db.m_sister.Add(m_sister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(m_sister);
        }

        //
        // GET: /Msister/Edit/5

        public ActionResult Edit(long id = 0)
        {
            m_sister m_sister = db.m_sister.Find(id);
            if (m_sister == null)
            {
                return HttpNotFound();
            }
            return View(m_sister);
        }

        //
        // POST: /Msister/Edit/5

        [HttpPost]
        public ActionResult Edit(m_sister m_sister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_sister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m_sister);
        }

        //
        // GET: /Msister/Delete/5

        public ActionResult Delete(long id = 0)
        {
            m_sister m_sister = db.m_sister.Find(id);
            if (m_sister == null)
            {
                return HttpNotFound();
            }
            return View(m_sister);
        }

        //
        // POST: /Msister/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            m_sister m_sister = db.m_sister.Find(id);
            db.m_sister.Remove(m_sister);
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