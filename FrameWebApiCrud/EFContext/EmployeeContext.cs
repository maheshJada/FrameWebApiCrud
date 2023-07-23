using FrameWebApiCrud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FrameWebApiCrud.EFContext
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext()
         : base("name=DbConnectionString")
        {

        }
        public DbSet<Employee> EmployeeNewWebApi { get; set; }
    }
}