using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ambulance.Models;

namespace Ambulance.Controllers
{

    [Authorize(Roles = "admin, doctor")]
    public class DoctorController : Controller
    {
        //
        // GET: /Doctor/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Osmotr()
        {
            long depNumb = (int)Session["DepNumb"];
            List<long> model = new List<long>();
            using (ambulanceEntities db = new ambulanceEntities())
            {
                //var d = (from p in db.ill_history where p.Date_out.Equals(DateTime.MinValue) select p.ill_id).ToList();
                //foreach(var l in d)
                //    System.Diagnostics.Debug.WriteLine(l);

                model = (from p in db.ill_history
                         where p.palata.OtdNumb.Equals(depNumb) && p.Date_out.Equals(DateTime.MinValue)
                         orderby p.ill_id ascending
                         select p.ill_id).ToList();
            }
            SelectList slist = new SelectList(model);
            ViewBag.Slist = slist;
                //var l = v.ToList();
               // ViewBag.list = list;
                //foreach (var item in v) //retrieve each item and assign to model
                //{
                //    model.Add(new RequestIds()
                //    {
                //        IdFirst = item.ill_id,
                //        IdSecond = item.pal_id,

                //    });
                //}
            return View(new historystr {Date=DateTime.Now });
                
           
        }

        [HttpPost]
       public ActionResult AfterOsmotr(historystr str)
        {
            //Здесь должно быть добавлениие записи в бд history_str
            str.dshifr = (int)Session["UserId"];
            System.Diagnostics.Debug.WriteLine("AfterOsmotr");
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Date " + str.Date + "ID " + str.ill_id);

                using (ambulanceEntities db = new ambulanceEntities())
                {
                    db.historystr.Add(str);
                    db.SaveChanges();
                }

            }
            return PartialView();
            
        }
        public ActionResult ListForLeave() 
        {
           return View();
        }

        public ActionResult CreateSp()
        {

            int depNumb = (int)Session["DepNumb"];
            List<PatCard> model = new List<PatCard>();
            using (Ambulance.ambulanceEntities db = new ambulanceEntities())
            {
                var res = (from p in db.ill_history
                           where  p.palata.OtdNumb == depNumb && p.Date_out.Equals(DateTime.MinValue)
                           select new { ill_id = p.ill_id, name = p.PName , diagn = p.Diagn_out}).ToList();
                foreach (var item in res)
                {
                    model.Add(new PatCard { Id = item.ill_id, Name = item.name,Diagn = item.diagn });
                }
            }
            return View(model);
        }

        public ActionResult CancelOfLeaving()
        {
            return View();
        }
    }
}
