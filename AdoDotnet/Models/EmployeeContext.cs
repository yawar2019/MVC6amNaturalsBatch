using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdoDotnet.Models
{
    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");
        public List<EmployeeModel> GetAllEmployees()
        {
            SqlCommand cmd = new SqlCommand("sp_employee", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<EmployeeModel> listEmp = new List<EmployeeModel>();

            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();

                emp.EmpId = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);
                listEmp.Add(emp);
            }

            return listEmp;
        }
    }
    }
