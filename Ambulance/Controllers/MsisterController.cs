using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ambulance.Controllers
{
    [Authorize(Roles="admin,msister")]
    public class MsisterController : Controller
    {
        //
        // GET: /Msister/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PalUnload()
        {
            return View();
        }
    }
}
