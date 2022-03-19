using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelFirstApproach.Models;

namespace ModelFirstApproach.Controllers
{
    public class EmployeeinfoesController : Controller
    {
        private EmployeeModelContainer db = new EmployeeModelContainer();

        // GET: Employeeinfoes
        public ActionResult Index()
        {
            return View(db.Employeeinfoes.ToList());
        }

        // GET: Employeeinfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeeinfo employeeinfo = db.Employeeinfoes.Find(id);
            if (employeeinfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeinfo);
        }

        // GET: Employeeinfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employeeinfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmpName,EmpSalary")] Employeeinfo employeeinfo)
        {
            if (ModelState.IsValid)
            {
                db.Employeeinfoes.Add(employeeinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeinfo);
        }

        // GET: Employeeinfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeeinfo employeeinfo = db.Employeeinfoes.Find(id);
            if (employeeinfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeinfo);
        }

        // POST: Employeeinfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmpName,EmpSalary")] Employeeinfo employeeinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeinfo);
        }

        // GET: Employeeinfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeeinfo employeeinfo = db.Employeeinfoes.Find(id);
            if (employeeinfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeinfo);
        }

        // POST: Employeeinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employeeinfo employeeinfo = db.Employeeinfoes.Find(id);
            db.Employeeinfoes.Remove(employeeinfo);
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
