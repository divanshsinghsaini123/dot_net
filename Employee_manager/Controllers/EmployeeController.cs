using Employee_manager.Services;
using Employees.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Employees.Controllers
{
    public class EmployeeController : Controller
    {
        private static Csv_Manager csv_model = new Csv_Manager();
        // yaha hmne store kiya h , csv ka data 
        // which is common across all the objects created from this file 
        private static List<EmpModel> lst = csv_model.loader();
        public IActionResult Index()
        {
            Console.WriteLine(lst.Count);

            return View(lst);
        }
        public IActionResult Create(int ? id )
        {
            if (id == null)
            {
                int lidx = lst.Count;
                if (lidx == 0)
                {
                    ViewBag.Id = 1;
                    
                }
                else
                {
                    ViewBag.id = lst[lidx - 1].Id + 1;
                }
                ViewBag.Message = "Create";
                return View();

            }
            
            ViewBag.Message = "Edit";
            ViewBag.Id = id;
            foreach (var emp in lst)
            {
                if (emp.Id == id)
                {
                    return View(emp);
                }
            }
            ViewBag.message = "Employee not found";
            return View("Index" , lst);
            
        }

        [HttpPost]
        public IActionResult Update(EmpModel x)
        {
           
            if (ModelState.IsValid) 
            {
                lst.Add(x);
                csv_model.CSV_updater(lst);
                ViewBag.message = "Data added Sucessfully";
                return View("index" , lst); 
            }
            ViewBag.message = "Data not added";
            //add to the list and Csv also
            //redirect to index page

            ViewBag.Id = x.Id;
            return View("create");
        }
        public IActionResult Edit(int id)
        { 
            ViewBag.id = id;
            foreach(var emp in lst)
            {
                if(emp.Id == id)
                {
                    return View(emp);
                }
            }
            ViewBag.message = "Employee not found";
            return View("Index");
        }

        
        public IActionResult Delete(int id)
        {
            foreach(var emp in lst)
            {
                Console.WriteLine(id);
                if (emp.Id == id)
                {
                    Console.WriteLine("found");
                    lst.Remove(emp);
                    csv_model.CSV_updater(lst);
                    ViewBag.message = "Employee Deleted Sucessfully";
                    return View("Index", lst);
                }
            }
            Console.WriteLine("debuger");
            ViewBag.message = "Data not deleted";
            return View("Index" ,lst);

        }
    }
}
