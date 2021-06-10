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
    public class DiscoesController : Controller
    {
        private DiscContext db = new DiscContext();

        // GET: Discoes
        public ActionResult Index()
        {
            var discos = db.Discos.Include(d => d.Artista).Include(d => d.Categoria);
            return View(discos.ToList());
        }

        // GET: Discoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disco disco = db.Discos.Find(id);
            if (disco == null)
            {
                return HttpNotFound();
            }
            return View(disco);
        }

        // GET: Discoes/Create
        public ActionResult Create()
        {
            ViewBag.ArtistaID = new SelectList(db.Artistas, "ID", "Nombre");
            ViewBag.CategoriaID = new SelectList(db.Categorias, "ID", "Cat");
            return View();
        }

        // POST: Discoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Fecha,Formato,Ncanciones,Precio,Observaciones,Imagen,ArtistaID,CategoriaID")] Disco disco)
        {
            if (ModelState.IsValid)
            {
                db.Discos.Add(disco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistaID = new SelectList(db.Artistas, "ID", "Nombre", disco.ArtistaID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "ID", "Cat", disco.CategoriaID);
            return View(disco);
        }

        // GET: Discoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disco disco = db.Discos.Find(id);
            if (disco == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistaID = new SelectList(db.Artistas, "ID", "Nombre", disco.ArtistaID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "ID", "Cat", disco.CategoriaID);
            return View(disco);
        }

        // POST: Discoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Fecha,Formato,Ncanciones,Precio,Observaciones,Imagen,ArtistaID,CategoriaID")] Disco disco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistaID = new SelectList(db.Artistas, "ID", "Nombre", disco.ArtistaID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "ID", "Cat", disco.CategoriaID);
            return View(disco);
        }

        // GET: Discoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disco disco = db.Discos.Find(id);
            if (disco == null)
            {
                return HttpNotFound();
            }
            return View(disco);
        }

        // POST: Discoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disco disco = db.Discos.Find(id);
            db.Discos.Remove(disco);
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
