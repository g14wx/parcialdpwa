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
using WebGrease.Css.Extensions;

namespace parcialdpwa.Controllers
{
    public class DetallePedidoesController : Controller
    {
        private DiscContext db = new DiscContext();

        // GET: DetallePedidoes
        public ActionResult Index(int idPedido)
        {
            ViewBag.idPedido = idPedido;
            var detallePedidos = db.DetallePedidos.Include(d => d.Disco).Include(d => d.Pedido);
            var detallespedidosFromIdPedido = detallePedidos.Where(dp => dp.PedidoID == idPedido);
            return View(detallespedidosFromIdPedido.ToList());
        }

        // GET: DetallePedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = db.DetallePedidos.Find(id);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Create
        public ActionResult Create(int? idPedido)
        {
            var discos = db.Discos;
            ViewBag.idPedido = idPedido;
            ViewBag.DiscoID = new SelectList(discos, "ID", "Titulo");
            ViewBag.PedidoID = new SelectList(db.Pedidos.Where(pe=>pe.ID == idPedido), "ID", "DireccionEntrega",selectedValue:idPedido);
            return View();
        }

        // POST: DetallePedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cantidad,PrecioVenta,PedidoID,DiscoID")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                db.DetallePedidos.Add(detallePedido);
                db.SaveChanges();
                return RedirectToAction(actionName:"Index",controllerName:"DetallePedidoes",routeValues:new {idPedido = detallePedido.PedidoID});
            }

            ViewBag.DiscoID = new SelectList(db.Discos, "ID", "Titulo", detallePedido.DiscoID);
            ViewBag.PedidoID = new SelectList(db.Pedidos, "ID", "DireccionEntrega", detallePedido.PedidoID);
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = db.DetallePedidos.Find(id);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiscoID = new SelectList(db.Discos, "ID", "Titulo", detallePedido.DiscoID);
            ViewBag.PedidoID = new SelectList(db.Pedidos, "ID", "DireccionEntrega", detallePedido.PedidoID);
            return View(detallePedido);
        }

        // POST: DetallePedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cantidad,PrecioVenta,PedidoID,DiscoID")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallePedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(actionName: "Index", controllerName: "DetallePedidoes", routeValues: new { idPedido = detallePedido.PedidoID });
            }
            ViewBag.DiscoID = new SelectList(db.Discos, "ID", "Titulo", detallePedido.DiscoID);
            ViewBag.PedidoID = new SelectList(db.Pedidos, "ID", "DireccionEntrega", detallePedido.PedidoID);
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = db.DetallePedidos.Find(id);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            return View(detallePedido);
        }

        // POST: DetallePedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetallePedido detallePedido = db.DetallePedidos.Find(id);
            db.DetallePedidos.Remove(detallePedido);
            db.SaveChanges();
            return RedirectToAction(actionName: "Index", controllerName: "DetallePedidoes", routeValues: new { idPedido = detallePedido.PedidoID });
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
