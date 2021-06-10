﻿using System;
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
    public class PedidoesController : Controller
    {
        private DiscContext db = new DiscContext();

        // GET: Pedidoes
        public ActionResult Index()
        {
            var reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                var pedidos = db.Pedidos.Include(p => p.Cliente).Include(p => p.Empleado);
                var EmpleadoID = reqCookies["EmnpleadoID"];
                if (EmpleadoID != null) return View(pedidos.ToList());
            }

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombres");
            ViewBag.EmpleadoID = new SelectList(db.Empleados, "ID", "Nombres");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FechaPedido,DireccionEntrega,Estado,ClienteID,EmpleadoID")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return RedirectToAction(actionName:"Index",controllerName:"DetallePedidoes",routeValues:new{ idPedido = pedido.ID});
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombres", pedido.ClienteID);
            ViewBag.EmpleadoID = new SelectList(db.Empleados, "ID", "Nombres", pedido.EmpleadoID);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombres", pedido.ClienteID);
            ViewBag.EmpleadoID = new SelectList(db.Empleados, "ID", "Nombres", pedido.EmpleadoID);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FechaPedido,DireccionEntrega,Estado,ClienteID,EmpleadoID")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombres", pedido.ClienteID);
            ViewBag.EmpleadoID = new SelectList(db.Empleados, "ID", "Nombres", pedido.EmpleadoID);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            db.Pedidos.Remove(pedido);
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
