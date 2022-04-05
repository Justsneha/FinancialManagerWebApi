using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDetailsWebApi.Models;

namespace UserDetailsWebApi.Controllers
{
    public class UserController : ApiController
    {
        public HttpResponseMessage GetDetails()
        {
            string Query = @"select UserId,FirstName,Location,Age from ProjectsampleDB.dbo.Users";
            DataTable table = new DataTable();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectsampleAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(Query, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, table);
            return response;

        }
        [HttpPost]
        public string PostData(Factoryproperties factoryobject)
        {
            string Query = @"insert into ProjectsampleDB.dbo.Users (FirstName,Location,Age) values
            ('"+factoryobject.FirstName+ @"','" + factoryobject.Location + @"','" + factoryobject.Age + @"')";
            DataTable table = new DataTable();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectsampleAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(Query, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return "Added details Successfuly";
        }
    }
}
 