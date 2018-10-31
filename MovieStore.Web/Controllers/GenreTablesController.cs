using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieStore.Web.Models;

namespace MovieStore.Web.Controllers
{
    public class GenreTablesController : Controller
    {
        private MovieStoreDB db = new MovieStoreDB();

        // GET: GenreTables
        public ActionResult Index()
        {
            return View(db.GenreTable.ToList());
        }

        // GET: GenreTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreTable genreTable = db.GenreTable.Find(id);
            if (genreTable == null)
            {
                return HttpNotFound();
            }
            return View(genreTable);
        }

        // GET: GenreTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] GenreTable genreTable)
        {
            if (ModelState.IsValid)
            {
                db.GenreTable.Add(genreTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genreTable);
        }

        // GET: GenreTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreTable genreTable = db.GenreTable.Find(id);
            if (genreTable == null)
            {
                return HttpNotFound();
            }
            return View(genreTable);
        }

        // POST: GenreTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] GenreTable genreTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genreTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genreTable);
        }

        // GET: GenreTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreTable genreTable = db.GenreTable.Find(id);
            if (genreTable == null)
            {
                return HttpNotFound();
            }
            return View(genreTable);
        }

        // POST: GenreTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenreTable genreTable = db.GenreTable.Find(id);
            db.GenreTable.Remove(genreTable);
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
