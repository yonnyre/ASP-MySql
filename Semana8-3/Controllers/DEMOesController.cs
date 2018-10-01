using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Semana8_3;

namespace Semana8_3.Controllers
{
    public class DEMOesController : Controller
    {
        private EJEMPLOMVCEntities db = new EJEMPLOMVCEntities();

        // GET: DEMOes
        public ActionResult Index()
        {
            return View(db.DEMO.ToList());
        }

        // GET: DEMOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEMO dEMO = db.DEMO.Find(id);
            if (dEMO == null)
            {
                return HttpNotFound();
            }
            return View(dEMO);
        }

        // GET: DEMOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DEMOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProveedor,Apellido,Nombre,Ruc,Credito")] DEMO dEMO)
        {
            if (ModelState.IsValid)
            {
                db.DEMO.Add(dEMO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dEMO);
        }

        // GET: DEMOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEMO dEMO = db.DEMO.Find(id);
            if (dEMO == null)
            {
                return HttpNotFound();
            }
            return View(dEMO);
        }

        // POST: DEMOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProveedor,Apellido,Nombre,Ruc,Credito")] DEMO dEMO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEMO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dEMO);
        }

        // GET: DEMOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEMO dEMO = db.DEMO.Find(id);
            if (dEMO == null)
            {
                return HttpNotFound();
            }
            return View(dEMO);
        }

        // POST: DEMOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEMO dEMO = db.DEMO.Find(id);
            db.DEMO.Remove(dEMO);
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
