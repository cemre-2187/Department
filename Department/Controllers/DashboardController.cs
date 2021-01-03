using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Department.Data;
using Department.Models;

namespace Department.Controllers
{
    public class DashboardController : Controller
    {
        private DepartmentContext db = new DepartmentContext();
        // GET: Dashboard
        public ActionResult Index(string sortOrder,string sortPrim , string searchString,string MinString,string MaxString)
        {

            //Departments department1 = new Departments() { DepartmentsId = 1, DepartmentName = "Yazılım" };
            //Departments department2 = new Departments() { DepartmentsId = 2, DepartmentName = "Maliye" };
            //Departments department3 = new Departments() { DepartmentsId = 3, DepartmentName = "Personel" };
            //Departments department4 = new Departments() { DepartmentsId = 4, DepartmentName = "Grafik" };

            //db.Departments.Add(department1);
            //db.Departments.Add(department2);
            //db.Departments.Add(department3);
            //db.Departments.Add(department4);
            //db.SaveChanges();



            //Job job1 = new Job() { JobId = 1, JobName = "Full-stack Developer", Salary = 6000, DepartmentId = 1 };
            //Job job2 = new Job() { JobId = 2, JobName = "Back-end Developer", Salary = 4000, DepartmentId = 1 };
            //Job job3 = new Job() { JobId = 3, JobName = "Front-end Developer", Salary = 3000, DepartmentId = 1 };
            //Job job4 = new Job() { JobId = 4, JobName = "Muhasebeci", Salary = 6000, DepartmentId = 2 };
            //Job job5 = new Job() { JobId = 5, JobName = "Personel Müdürü", Salary = 7000, DepartmentId = 3 };
            //Job job6 = new Job() { JobId = 6, JobName = "Tasarımcı", Salary = 4000, DepartmentId = 4 };

            //db.Jobs.Add(job1);
            //db.Jobs.Add(job2);
            //db.Jobs.Add(job3);
            //db.Jobs.Add(job4);
            //db.Jobs.Add(job5);
            //db.Jobs.Add(job6);
            //db.SaveChanges();

            //Person person = new Person { PersonId=1,  Name = "Ahmet Yıldırım", BeginDate= new DateTime(2019, 01, 01), Grad="Lisans", JobId=1, Prim=300, sex="Erkek", Tecnology="React Js" };
            //Person person1 = new Person { PersonId = 1, Name = "Ahmet Yıldırım", BeginDate = new DateTime(2019, 01, 01), Grad = "Lisans", JobId = 1, Prim = 300, sex = "Erkek", Tecnology = "ASP.NET" };
            //Person person2 = new Person { PersonId = 1, Name = "Ahmet Yıldırım", BeginDate = new DateTime(2019, 01, 01), Grad = "Lisans", JobId = 2, Prim = 300, sex = "Erkek", Tecnology = "Node Js" };
            //Person person3 = new Person { PersonId = 1, Name = "Ahmet Yıldırım", BeginDate = new DateTime(2019, 01, 01), Grad = "Lisans", JobId = 2, Prim = 300, sex = "Erkek", Tecnology = "Php" };
            //Person person4 = new Person { PersonId = 1, Name = "Ahmet Yıldırım", BeginDate = new DateTime(2019, 01, 01), Grad = "Lisans", JobId = 3, Prim = 300, sex = "Erkek", Tecnology = "Vue Js" };
            //Person person5 = new Person { PersonId = 1, Name = "Ahmet Yıldırım", BeginDate = new DateTime(2019, 01, 01), Grad = "Lisans", JobId = 3, Prim = 300, sex = "Erkek", Tecnology = "React Js" };
            //Person person6 = new Person { PersonId = 1, Name = "Ahmet Yıldırım", BeginDate = new DateTime(2019, 01, 01), Grad = "Lisans", JobId = 4, Prim = 300, sex = "Erkek", Tecnology = "Nebim Winner" };
            //Person person7 = new Person { PersonId = 1, Name = "Ahmet Yıldırım", BeginDate = new DateTime(2019, 01, 01), Grad = "Lisans", JobId = 4, Prim = 300, sex = "Erkek", Tecnology = "Stok Takibi" };
            //Person person8 = new Person { PersonId = 1, Name = "Ahmet Yıldırım", BeginDate = new DateTime(2019, 01, 01), Grad = "Lisans", JobId = 5, Prim = 300, sex = "Erkek", Tecnology = "PYS" };
            //Person person9 = new Person { PersonId = 1, Name = "Ahmet Yıldırım", BeginDate = new DateTime(2019, 01, 01), Grad = "Lisans", JobId = 6, Prim = 300, sex = "Erkek", Tecnology = "Fatura Programı" };
            //Person person10 = new Person { PersonId = 1, Name = "Ahmet Yıldırım", BeginDate = new DateTime(2019, 01, 01), Grad = "Lisans", JobId = 6, Prim = 300, sex = "Erkek", Tecnology = "Muhasebe Programı" };
            //db.Persons.Add(person1);
            //db.Persons.Add(person2);
            //db.Persons.Add(person3);
            //db.Persons.Add(person4);
            //db.Persons.Add(person5);
            //db.Persons.Add(person6);
            //db.Persons.Add(person7);
            //db.Persons.Add(person8);
            //db.Persons.Add(person9);
            //db.Persons.Add(person10);
            //db.SaveChanges();




            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PrimSortParm = String.IsNullOrEmpty(sortPrim) ? "Prim" : "";

           

            var AllPersons = db.Persons.Include(q => q.JobId.DepartmentId);
            if (sortOrder == "name_desc")
            {
                AllPersons = AllPersons.OrderBy(i => i.Name);
            }
            if (sortPrim == "Prim")
            {
                AllPersons = AllPersons.OrderByDescending(i => i.Prim);
            }
            
            if(MinString!=null && MaxString!=null)
            {
                int Max = int.Parse(MaxString);
                int Min = int.Parse(MinString);
                AllPersons = AllPersons.Where(i =>Max > i.Prim).Where(i=>i.Prim> Min);
            }

            
           
            if (!String.IsNullOrEmpty(searchString))
            {
                AllPersons = AllPersons.Where(s=>s.Name.Contains(searchString));
            }

           
            return View(AllPersons.ToList());
          
        }
    }
}