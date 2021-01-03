using Department.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Department.Data
{
    public class DepartmentContext:DbContext
    {
      


        public DbSet<Person> Persons { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public DbSet<Departments> Departments { get; set; }


    }
}