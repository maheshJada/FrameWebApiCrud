using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrameWebApiCrud.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpDisg { get; set; }
        public string EmpSalary { get; set; }

    }
}