using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeStatusDashboard.Models;
using Newtonsoft.Json.Linq;
using System.Text;

namespace EmployeeStatusDashboard.Controllers
{
    /// <summary>
    /// Employees Controller
    /// </summary>
    public class EmployeesController : ApiController
    {
        private GEPTestEntities gepEntity = new GEPTestEntities();

        /// <summary>
        /// Fetch Employees
        /// </summary>
        /// <param name="data">Parameter object</param>
        /// <returns>Returns HttpResponseMessage</returns>
        public HttpResponseMessage Post(JObject data)
        {
            if(!data.HasValues)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                //Read parameters
                int deptID = data["deptId"].ToObject<int>();
                bool status = data["status"].ToObject<bool>();
                DateTime date = data["date"].ToObject<DateTime>();

                //Get employees based on selected date & status from EmployeeStatus table
                var employeelist = gepEntity.EmployeeStatus.Where(s => 
                                                            (s.LoginDate == date.Date) && 
                                                            (s.Status == status)).Select(t => 
                                                                                    new { t.EmpID, t.Status });

                //Retrieve employee details
                var employeeObj = (from emp in gepEntity.Employees.Where(e => 
                                                                    (employeelist.Select(t => 
                                                                        t.EmpID).Contains(e.EmpID)) && 
                                                                        (e.DeptID == deptID))
                                   join dept in gepEntity.Departments on emp.DeptID equals dept.DeptID
                                   join empstatus in employeelist on emp.EmpID equals empstatus.EmpID
                                   select new
                                   {
                                       empId = emp.EmpID,
                                       firstName = emp.FirstName,
                                       lastName = emp.LastName,
                                       dob = emp.DateOfBirth,
                                       joiningDate = emp.JoiningDate,
                                       deptName = dept.DeptName,
                                       status = empstatus.Status
                                   });


                //Retun employee details
                return new HttpResponseMessage()
                {
                    Content = new StringContent(JArray.FromObject(employeeObj).ToString(), Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception)
            {

                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }       
    }
}