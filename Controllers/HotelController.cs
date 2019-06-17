using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektHotele.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Hotel()
        {
            return View();
        }
    }
}