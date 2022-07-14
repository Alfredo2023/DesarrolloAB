using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesarrolloAB.Models;

namespace DesarrolloAB.Controllers
{
    public class SucursalesController : Controller
    {
        private ABONAPEntities1 db = new ABONAPEntities1();

        // GET: Sucursales
        public ActionResult Index()
        {
            return View(db.Sucursales.ToList());
        }

        // GET: Sucursales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursale sucursale = db.Sucursales.Find(id);
            if (sucursale == null)
            {
                return HttpNotFound();
            }
            return View(sucursale);
        }

        // GET: Sucursales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sucursales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSucursales,IdEmpresa,Descripcion,Codigo,Estado,FechaActualizacion,FechaCreación")] Sucursale sucursale)
        {
            if (ModelState.IsValid)
            {
                db.Sucursales.Add(sucursale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sucursale);
        }

        // GET: Sucursales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursale sucursale = db.Sucursales.Find(id);
            if (sucursale == null)
            {
                return HttpNotFound();
            }
            return View(sucursale);
        }

        // POST: Sucursales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSucursales,IdEmpresa,Descripcion,Codigo,Estado,FechaActualizacion,FechaCreación")] Sucursale sucursale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sucursale);
        }

        // GET: Sucursales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursale sucursale = db.Sucursales.Find(id);
            if (sucursale == null)
            {
                return HttpNotFound();
            }
            return View(sucursale);
        }

        // POST: Sucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sucursale sucursale = db.Sucursales.Find(id);
            db.Sucursales.Remove(sucursale);
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
