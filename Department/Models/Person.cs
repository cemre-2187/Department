using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Department.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public string Grad { get; set; }
        public string sex { get; set; }
        public string Tecnology { get; set; }
        public int Prim { get; set; }
        public Job  JobId { get; set; }


    }
}