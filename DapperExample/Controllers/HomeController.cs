using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using DapperExample.Models;
using System.Data.SqlClient;

namespace DapperExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");

        public ActionResult Index()
        {

            //var listEmployee = con.Query<EmployeeModel>("SELECT  [EmpId],[EmpName],[EmpSalary] FROM [Employee].[dbo].[employeeDetails]");
            var listEmployee = con.Query<EmployeeModel>("sp_employee", commandType: System.Data.CommandType.StoredProcedure);
            return View(listEmployee);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            var param = new DynamicParameters();
            param.Add("@EmpName", emp.EmpName);
            param.Add("@EmpSalary", emp.EmpSalary);

            int result = con.Execute("sp_CreateEmployee",param: param, commandType:System.Data.CommandType.StoredProcedure);
            if(result>0)
            return RedirectToAction("index");
            else
                return View();
        }
    }
}