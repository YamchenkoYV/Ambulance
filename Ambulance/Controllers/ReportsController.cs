using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ambulance.Controllers
{   
    [Authorize]
    public class ReportsController : Controller
    {

        ambulanceEntities db = new ambulanceEntities();
        //
        // GET: /Reports/


        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Report1()
        {
            return View();
        }
        public ActionResult Report2()
        {
            return View();
        }
        public ActionResult Report3()
        {
            return View();
        }
        public ActionResult Report4()
        {
            return View();
        }
        public ActionResult Report5()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AfterReport1(int date = 0)
        {
            using (ambulanceEntities dc = new ambulanceEntities())
            {

                //var v = dc.ill_history.Where(b => b.Date_in.Year.Equals(date)).GroupBy(b=>b.Date_in.Month).ToDictionary(b=>b.Key,b=>b.ToList());
                System.Linq.IQueryable<IGrouping<Int32, Ambulance.ill_history>> v = from p in db.ill_history where p.Date_in.Year.Equals(date) group p by p.Date_in.Month;

                if (v.Count() != 0)
                    return PartialView(v);
                 else
                    return PartialView("ErrorReport",date);
            }
        }
    }
}
