using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class APIsController : Controller
    {
        private ApiContext db = new ApiContext();

        // GET: APIs
        public ActionResult Index()
        {
            return View(db.APIs.ToList());
        }

        // GET: APIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            API aPI = db.APIs.Find(id);
            if (aPI == null)
            {
                return HttpNotFound();
            }
            return View(aPI);
        }

        // GET: APIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: APIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Url")] API aPI)
        {
            if (ModelState.IsValid)
            {
                db.APIs.Add(aPI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aPI);
        }

        // GET: APIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            API aPI = db.APIs.Find(id);
            if (aPI == null)
            {
                return HttpNotFound();
            }
            return View(aPI);
        }

        // POST: APIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Url")] API aPI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aPI);
        }

        // GET: APIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            API aPI = db.APIs.Find(id);
            if (aPI == null)
            {
                return HttpNotFound();
            }
            return View(aPI);
        }

        // POST: APIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            API aPI = db.APIs.Find(id);
            db.APIs.Remove(aPI);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("GetData")]
        public JsonResult GetDataFromApi(int id)
        {
            API api = db.APIs.Find(id);
            return Json(api.GetData(), JsonRequestBehavior.AllowGet);
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
