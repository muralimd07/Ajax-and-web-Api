using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using webap.Models;
using System.Data.SqlClient;
using System.Data;

namespace webap.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class ValuesController : ApiController
    {
    
        
        [HttpGet]
        [Route("api/values")]
        public HttpResponseMessage GetAllPatients()
        {
            DataTable table = new DataTable();
            string query = @"select * from employee";

            using (var con = new SqlConnection(@"Data Source=DHHCL67YYDB3\SQLEXPRESS;Initial Catalog=employee;Integrated Security=True"))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);

            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [HttpGet]
       
        // GET api/values/5
        public HttpResponseMessage GetPatient(int id)
        {
            DataTable table = new DataTable();
            string query = @"select * from employee where empid=@id";

            using (var con = new SqlConnection(@"Data Source=DHHCL67YYDB3\SQLEXPRESS;Initial Catalog=employee;Integrated Security=True"))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                da.Fill(table);

            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
      
  
        [HttpPost]
        [Route("api/values")]
        public HttpResponseMessage AddPatient([FromBody] Employee employee)
        {
            DataTable table = new DataTable();
            string query = "insert into employee values(@id,@name,@dob);";

            using (var con = new SqlConnection(@"Data Source = DHHCL67YYDB3\SQLEXPRESS; Initial Catalog = employee; Integrated Security = True"))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id",employee.Empid));
                cmd.Parameters.Add(new SqlParameter("@name",employee.Empname));
                cmd.Parameters.Add(new SqlParameter("@dob", employee.EmpDob));
                da.Fill(table);

            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
