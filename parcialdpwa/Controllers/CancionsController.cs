using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using parcialdpwa.DAL;
using parcialdpwa.Models;

namespace parcialdpwa.Controllers
{
    public class CancionsController : Controller
    {
        private DiscContext db = new DiscContext();

        // GET: Cancions
        public ActionResult Index()
        {
            var reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                var canciones = db.Canciones.Include(c => c.Disco);
                var EmpleadoID = reqCookies["EmnpleadoID"];
                if (EmpleadoID != null) return View(canciones.ToList());
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
           
        }

        // GET: Cancions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancion cancion = db.Canciones.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            return View(cancion);
        }

        // GET: Cancions/Create
        public ActionResult Create()
        {
            ViewBag.DiscoID = new SelectList(db.Discos, "ID", "Titulo");
            return View();
        }

        // POST: Cancions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Numero,Tiempo,cancion,DiscoID")] Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                db.Canciones.Add(cancion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiscoID = new SelectList(db.Discos, "ID", "Titulo", cancion.DiscoID);
            return View(cancion);
        }

        // GET: Cancions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancion cancion = db.Canciones.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiscoID = new SelectList(db.Discos, "ID", "Titulo", cancion.DiscoID);
            return View(cancion);
        }

        // POST: Cancions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Numero,Tiempo,cancion,DiscoID")] Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cancion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiscoID = new SelectList(db.Discos, "ID", "Titulo", cancion.DiscoID);
            return View(cancion);
        }

        // GET: Cancions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancion cancion = db.Canciones.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            return View(cancion);
        }

        // POST: Cancions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cancion cancion = db.Canciones.Find(id);
            db.Canciones.Remove(cancion);
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
    }
}
