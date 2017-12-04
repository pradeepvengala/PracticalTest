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
    /// Departments Controller
    /// </summary>
    public class DepartmentsController : ApiController
    {
        private GEPTestEntities gepEntity = new GEPTestEntities();

        /// <summary>
        /// GET: api/Departments
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage Get()
        {
            try
            {
                // Return Department list
                return new HttpResponseMessage()
                {
                    Content = new StringContent(JArray.FromObject(gepEntity.Departments.Select(d =>
                        new
                        {
                            d.DeptID,
                            d.DeptName
                        })).ToString(), Encoding.UTF8, "application/json"),
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
