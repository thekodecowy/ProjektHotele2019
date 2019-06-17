using ProjektHotele.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektHotele.Controllers
{
    public class Home2Controller : Controller
    {
        private HotelsDBEntities _db = new HotelsDBEntities();
        // GET: Home2
        public ActionResult Home2()
        {
            return View(_db.Hotels.ToList());
        }
        public ActionResult Home2Klient()
        {
            return View(_db.Hotels.ToList());
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Hotel HotelToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            _db.Hotels.Add(HotelToCreate);
            _db.SaveChanges();
            return RedirectToAction("Home2");

        }
        public ActionResult Edit(int id)
        {
            var HotelToEdit = (from m in _db.Hotels
                               where m.Id == id
                               select m).First();
            return View(HotelToEdit);
        }
        // POST: Default/Create
        [HttpPost]
        public ActionResult Edit(Hotel HotelToEdit)
        {
            var orginalhotel = (from m in _db.Hotels
                                where m.Id == HotelToEdit.Id
                                select m).First();

            if (!ModelState.IsValid)
                return View(orginalhotel);

            _db.Entry(orginalhotel).CurrentValues.SetValues(HotelToEdit);
            _db.SaveChanges();
            return RedirectToAction("Home2");

        }
        public ActionResult rezKlient(int id)
        {
            var HotelToEdit = (from m in _db.Hotels
                               where m.Id == id
                               select m).First();
            return View(HotelToEdit);
        }
        // POST: Default/Create
        [HttpPost]
        public ActionResult rezKlient(Hotel HotelToEdit)
        {
            var orginalhotel = (from m in _db.Hotels
                                where m.Id == HotelToEdit.Id
                                select m).First();

            if (!ModelState.IsValid)
                return View(orginalhotel);

            _db.Entry(orginalhotel).CurrentValues.SetValues(HotelToEdit);
            _db.SaveChanges();
            return RedirectToAction("Home2Klient");

        }
    }
}