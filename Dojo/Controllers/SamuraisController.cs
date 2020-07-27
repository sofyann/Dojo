using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dojo.Data;
using Dojo.Models;
using Dojo.Utils.Validators;
using Entities;

namespace Dojo.Controllers
{
    public class SamuraisController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: Samurais
        public ActionResult Index()
        {
            return View(db.Samurais.ToList());
        }

        // GET: Samurais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samurai samurai = db.Samurais.Find(id);
            if (samurai == null)
            {
                return HttpNotFound();
            }
            return View(samurai);
        }

        // GET: Samurais/Create
        public ActionResult Create()
        {
            SamuraiViewModel svm = new SamuraiViewModel()
            {
                armes = db.Armes.ToList()
            };

            return View(svm);
        }

        // POST: Samurais/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamuraiViewModel svm)
        {
            svm.armes = db.Armes.ToList();
            if (ModelState.IsValid && SamuraiValidator.Validate(svm, ModelState, db))
            {
                db.Samurais.Add(svm.Samurai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(svm);
        }

        // GET: Samurais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samurai samurai = db.Samurais.Find(id);
            if (samurai == null)
            {
                return HttpNotFound();
            }
            SamuraiViewModel svm = new SamuraiViewModel()
            {
                armes = db.Armes.ToList(),
                Samurai = samurai,
                armeId = (samurai.Arme == null ? 0 : samurai.Arme.Id) 
            };
            return View(svm);
        }

        // POST: Samurais/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamuraiViewModel svm)
        {
            svm.armes = db.Armes.ToList();
            if (ModelState.IsValid && SamuraiValidator.Validate(svm, ModelState, db))
            {
                db.Entry(svm.Samurai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(svm);
        }

        // GET: Samurais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samurai samurai = db.Samurais.Find(id);
            if (samurai == null)
            {
                return HttpNotFound();
            }
            return View(samurai);
        }

        // POST: Samurais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samurai samurai = db.Samurais.Find(id);
            db.Samurais.Remove(samurai);
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
