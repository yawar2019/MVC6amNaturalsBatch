using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using databaseFirstApproach.Models;

namespace databaseFirstApproach.Controllers
{
    public class employeeDetailsController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: employeeDetails
        public ActionResult Index()
        {
            return View(db.employeeDetails.ToList());
        }
        public ActionResult Index2()
        {
            var emplist = (from emp in db.employeeDetails
                           join dept in db.Departments
                           on emp.DeptId equals dept.DeptId
                           select new Empdept
                           {
                               EmpId = emp.EmpId,
                               EmpName = emp.EmpName,
                               EmpSalary = emp.EmpSalary,
                               DeptName = dept.DeptName,
                           }).ToList();

            return View(emplist);
        }

        public ActionResult Index3()
        {
            var emplist = db.sp_employee().ToList();

            return View(emplist);
        }
        // GET: employeeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeDetail employeeDetail = db.employeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // GET: employeeDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,EmpName,EmpSalary,DeptId,Address,dob,Mobiles,Status,CreatedBy,MobileNo,Available,CreatedOn,bonus")] employeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                //db.employeeDetails.Add(employeeDetail);
                //db.SaveChanges();
                db.sp_CreateEmployee(employeeDetail.EmpName, employeeDetail.EmpSalary,employeeDetail.DeptId);
                return RedirectToAction("Index");
            }

            return View(employeeDetail);
        }

        // GET: employeeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeDetail employeeDetail = db.employeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // POST: employeeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,EmpName,EmpSalary,DeptId,Address,dob,Mobiles,Status,CreatedBy,MobileNo,Available,CreatedOn,bonus")] employeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDetail);
        }

        // GET: employeeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeDetail employeeDetail = db.employeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // POST: employeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeDetail employeeDetail = db.employeeDetails.Find(id);
            db.employeeDetails.Remove(employeeDetail);
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
