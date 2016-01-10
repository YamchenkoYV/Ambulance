using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ambulance.Models;

namespace Ambulance.Controllers
{
    [Authorize(Roles="admin,doctor")]
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
        List<Rep2> list = new List<Rep2>();
        
        using (ambulanceEntities db = new ambulanceEntities())
            {
                var v = (from p in db.ill_history 
                          where p.Date_out.Equals(DateTime.MinValue)  group p by p.shifr).ToList();

                foreach (var item in v)
                {
                    list.Add(new Rep2{name = item.First().doctors.d_name, profile = item.ToList()});
                }
                return View(list);
            }
            
        }
        public ActionResult Report3()
        {
            List<Rep2> list = new List<Rep2>();

            using (ambulanceEntities db = new ambulanceEntities())
            {
                var v = (from p in db.ill_history
                         where p.Diagn_in.Equals(p.Diagn_out)
                         group p by p.shifr).ToList();
                foreach (var item in v)
                {
                    list.Add(new Rep2 { name = item.First().doctors.d_name, profile = item.ToList() });
                }
                return View(list);
            }
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
                System.Linq.IQueryable<IGrouping<Int32, Ambulance.ill_history>> v = from p in db.ill_history  where p.Date_in.Year.Equals(date) group p by p.Date_in.Month;

                if (v.Count() != 0)
                    return PartialView(v);
                 else
                    return PartialView("ErrorReport",date);
            }
        }
        [HttpPost] //Td
        public ActionResult AfterReport4(int date = 0)
        {
            using (ambulanceEntities dc = new ambulanceEntities())
            {

                //var v = dc.ill_history.Where(b => b.Date_in.Year.Equals(date)).GroupBy(b=>b.Date_in.Month).ToDictionary(b=>b.Key,b=>b.ToList());
                var v = from p in db.ill_history where p.Date_in.Year.Equals(date) group p by p.Date_in.Month;
                if (v.Count() != 0)
                    return PartialView(v);
                else
                    return PartialView("ErrorReport", date);
            }
        }

        [HttpPost]//Td
        public ActionResult AfterReport5(int date = 0)
        {
            using (ambulanceEntities dc = new ambulanceEntities())
            {

                //var v = dc.ill_history.Where(b => b.Date_in.Year.Equals(date)).GroupBy(b=>b.Date_in.Month).ToDictionary(b=>b.Key,b=>b.ToList());
                var v = from p in db.ill_history where p.Date_in.Year.Equals(date) group p by p.Date_in.Month;
                if (v.Count() != 0)
                    return PartialView(v);
                else
                    return PartialView("ErrorReport", date);
            }
        }

        public ActionResult Info(long id = 33)
        {
            using (ambulanceEntities db = new ambulanceEntities())
            {
                var v = (from p in db.ill_history where p.ill_id == id select p).First();
                
            
            return View(v);
            }
        }
    }
}
