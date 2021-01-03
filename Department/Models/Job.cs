using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Department.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public int Salary { get; set; }
        public Departments DepartmentId { get; set; }
        public List<Person> Persons { get; set; }
    }
  
}