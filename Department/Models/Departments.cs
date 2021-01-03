using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Department.Models
{
    public class Departments
    {
        public int DepartmentsId { get; set; }
        public string DepartmentName { get; set; }
        public List<Job> Jobs { get; set; }
    }
  
}