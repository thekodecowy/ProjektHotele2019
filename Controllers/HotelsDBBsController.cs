using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektHotele.Models;

namespace ProjektHotele.Controllers
{
    public class HotelsDBBsController : Controller
    {
        private HotelsDBEntities1 db = new HotelsDBEntities1();

  
        public ActionResult Index()
        {
            var hotelsDBBs = db.HotelsDBBs.Include(h => h.Rodzpl).Include(h => h.Stann);
            return View(hotelsDBBs.ToList());
        }
        public ActionResult KlientIndex()
        {
            var hotelsDBBs = db.HotelsDBBs.Include(h => h.Rodzpl).Include(h => h.Stann);
            return View(hotelsDBBs.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelsDBB hotelsDBB = db.HotelsDBBs.Find(id);
            if (hotelsDBB == null)
            {
                return HttpNotFound();
            }
            return View(hotelsDBB);
        }

   
        public ActionResult Create()
        {
            ViewBag.RodzajPlatnosci = new SelectList(db.Rodzpls, "Id_rodzajplatnosci", "Rodzajplatnosci");
            ViewBag.Stan = new SelectList(db.Stanns, "idStan", "Stan");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Numer,Standard,DataDodanie,opis,Cena,Imie,Nazwisko,WynajemOd,WynajemDo,RodzajPlatnosci,Stan")] HotelsDBB hotelsDBB)
        {
            if (ModelState.IsValid)
            {
                db.HotelsDBBs.Add(hotelsDBB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RodzajPlatnosci = new SelectList(db.Rodzpls, "Id_rodzajplatnosci", "Rodzajplatnosci", hotelsDBB.RodzajPlatnosci);
            ViewBag.Stan = new SelectList(db.Stanns, "idStan", "Stan", hotelsDBB.Stan);
            return View(hotelsDBB);
        }

    
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelsDBB hotelsDBB = db.HotelsDBBs.Find(id);
            if (hotelsDBB == null)
            {
                return HttpNotFound();
            }
            ViewBag.RodzajPlatnosci = new SelectList(db.Rodzpls, "Id_rodzajplatnosci", "Rodzajplatnosci", hotelsDBB.RodzajPlatnosci);
            ViewBag.Stan = new SelectList(db.Stanns, "idStan", "Stan", hotelsDBB.Stan);
            return View(hotelsDBB);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Numer,Standard,DataDodanie,opis,Cena,Imie,Nazwisko,WynajemOd,WynajemDo,RodzajPlatnosci,Stan")] HotelsDBB hotelsDBB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelsDBB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RodzajPlatnosci = new SelectList(db.Rodzpls, "Id_rodzajplatnosci", "Rodzajplatnosci", hotelsDBB.RodzajPlatnosci);
            ViewBag.Stan = new SelectList(db.Stanns, "idStan", "Stan", hotelsDBB.Stan);
            return View(hotelsDBB);
        }

 
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelsDBB hotelsDBB = db.HotelsDBBs.Find(id);
            if (hotelsDBB == null)
            {
                return HttpNotFound();
            }
            return View(hotelsDBB);
        }

        // POST: HotelsDBBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelsDBB hotelsDBB = db.HotelsDBBs.Find(id);
            db.HotelsDBBs.Remove(hotelsDBB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult rezKlient(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelsDBB hotelsDBB = db.HotelsDBBs.Find(id);
            if (hotelsDBB == null)
            {
                return HttpNotFound();
            }
            ViewBag.RodzajPlatnosci = new SelectList(db.Rodzpls, "Id_rodzajplatnosci", "Rodzajplatnosci", hotelsDBB.RodzajPlatnosci);
            ViewBag.Stan = new SelectList(db.Stanns, "idStan", "Stan", hotelsDBB.Stan);
            return View(hotelsDBB);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult rezKlient([Bind(Include = "Id,Nazwa,Numer,Standard,DataDodanie,opis,Cena,Imie,Nazwisko,WynajemOd,WynajemDo,RodzajPlatnosci,Stan")] HotelsDBB hotelsDBB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelsDBB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("KlientIndex");
            }
            ViewBag.RodzajPlatnosci = new SelectList(db.Rodzpls, "Id_rodzajplatnosci", "Rodzajplatnosci", hotelsDBB.RodzajPlatnosci);
            ViewBag.Stan = new SelectList(db.Stanns, "idStan", "Stan", hotelsDBB.Stan);
            return View(hotelsDBB);
        }
    }
}
