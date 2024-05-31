using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Web.Http;
using Newtonsoft.Json;

namespace trialwebapi
{
    public class PController : ApiController
    {








        // GET api/<controller>
        //public IEnumerable<Employee> Get()
        /*public IHttpActionResult Get()   
        {
            List<Employee> employees = new List<Employee>();

            string connectionString = ConfigurationManager.ConnectionStrings["smsystemconn"].ConnectionString;
            string query = "SELECT * FROM user1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = reader.GetInt32(0);
                        employee.Name = reader.GetString(1);
                        // Add more properties as needed

                        employees.Add(employee);
                    }
                }
            }

            return Ok(employees);// for Json Retrun
            //return employees; for html retrun

        }*/

        public IHttpActionResult Get()
        {
            List<Employee> employees = new List<Employee>();

            string connectionString = ConfigurationManager.ConnectionStrings["smsystemconn"].ConnectionString;
            //string query = "SELECT studname FROM stud_master";
            string query = "SELECT * FROM user1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = reader.GetInt32(0);
                        employee.Name = reader.GetString(1);
                        // Add more properties as needed

                        employees.Add(employee);
                    }
                }
            }
            string json = JsonConvert.SerializeObject(employees);
            return Ok(json);
            //return Ok(employees);
        }




        public IHttpActionResult Get(int id)
        {
            List<Employee> employees = new List<Employee>();

            string connectionString = ConfigurationManager.ConnectionStrings["smsystemconn"].ConnectionString;
            string query = "SELECT * FROM user1 where id="+id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        if (!reader.HasRows)
                        {
                            return NotFound();
                        }

                        Employee employee = new Employee();
                        employee.Id = reader.GetInt32(0);
                        employee.Name = reader.GetString(1);
                        // Add more properties as needed

                        employees.Add(employee);
                    }
                }
            }

            string json = JsonConvert.SerializeObject(employees);
            return Ok(json);

        }


        // POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}
        [HttpPost]
        // POST: api/employees
        
        public IHttpActionResult Post(Employee employee)
        {
            try
            {
                // Check if the 'Name' property is null or empty
               // if (string.IsNullOrEmpty(employee.Name))
               // {
                    //return BadRequest("Employee name cannot be empty.");
                //}

                string connectionString = ConfigurationManager.ConnectionStrings["smsystemconn"].ConnectionString;
                string query = "INSERT INTO user1 ( name) VALUES ( @name)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //command.Parameters.AddWithValue("@id", employee.Id);
                        command.Parameters.AddWithValue("@name", employee.Name);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Record inserted successfully");
                        }
                        else
                        {
                            return InternalServerError(new Exception("Failed to insert record"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Add more properties as needed
    }
    public class Employeess
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        // Add more properties as needed
    }
}