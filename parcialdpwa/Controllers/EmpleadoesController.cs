using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using parcialdpwa.DAL;
using parcialdpwa.Entities;
using parcialdpwa.Models;

namespace parcialdpwa.Controllers
{
    public class EmpleadoesController : Controller
    {
        private DiscContext db = new DiscContext();

       

        // GET: Empleadoes
        public ActionResult Index()
        {
            var reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                var EmpleadoID = reqCookies["EmnpleadoID"];
                if (EmpleadoID != null) return View(db.Empleados.ToList());
            }

            return RedirectToAction(actionName: "Index", controllerName: "Home");
            
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empleado empleado = db.Empleados.Find(id);

            List<SelledDisk> listSelledDisks = (from d in db.Discos
                          join dp in db.DetallePedidos
                          on d.ID equals dp.DiscoID
                          join p in db.Pedidos
                          on dp.PedidoID equals p.ID
                          join e in db.Empleados
                          on p.EmpleadoID equals e.ID
                          where e.ID == id
                          select new SelledDisk  
                          {
                              ID = d.ID,
                              Titulo = d.Titulo
                          }).Distinct().ToList();

            empleado.listSelledDisks = listSelledDisks;

            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        public ActionResult selledDiskBydate(int idEmployee, String startDateS, String endDateS)
        {
            if (idEmployee == null || startDateS == null || endDateS == null || startDateS == "" || endDateS == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empleado empleado = db.Empleados.Find(idEmployee);


            DateTime startDate = Convert.ToDateTime(startDateS);
            DateTime endDate = Convert.ToDateTime(endDateS);

            List<SelledDisk> listSelledDisks = (from d in db.Discos
                                                join dp in db.DetallePedidos
                                                on d.ID equals dp.DiscoID
                                                join p in db.Pedidos
                                                on dp.PedidoID equals p.ID
                                                join e in db.Empleados
                                                on p.EmpleadoID equals e.ID
                                                where e.ID == idEmployee &&  (p.FechaPedido >= startDate && p.FechaPedido <= endDate)
                                                select new SelledDisk
                                                {
                                                    ID = d.ID,
                                                    Titulo = d.Titulo
                                                }).Distinct().ToList();

            empleado.listSelledDisks = listSelledDisks;

            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombres,Apellidos,Direccion,login,clave")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombres,Apellidos,Direccion,login,clave")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            db.Empleados.Remove(empleado);
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
