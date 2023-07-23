using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FrameWebApiCrud.EFContext;
using FrameWebApiCrud.Models;

namespace FrameWebApiCrud.Controllers
{
    public class EmployeesController : ApiController
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: api/Employees
        [HttpGet]
        public IQueryable<Employee> GetEmployeeNewWebApi()
        {
            return db.EmployeeNewWebApi;
        }
        [HttpGet]
        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.EmployeeNewWebApi.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [HttpPut]

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmpID)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpPost]
        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeNewWebApi.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.EmpID }, employee);
        }
        [HttpDelete]
        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.EmployeeNewWebApi.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.EmployeeNewWebApi.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.EmployeeNewWebApi.Count(e => e.EmpID == id) > 0;
        }
    }
}