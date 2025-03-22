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
        private static List<Emp>lst = csv_model.loader();
        public IActionResult Index()
        {
            Console.WriteLine(lst.Count);

            return View(lst);
        }
        public IActionResult Create()
        {
            int lidx = lst.Count;
            if(lidx==0)
            {
                ViewBag.id = 1;
            }
            else
            {
                ViewBag.id = lst[lidx - 1].id + 1;
            }
            
            //check present of not
            return View();
        }

        [HttpPost]
        public IActionResult Update()
        {

            //add to the list and Csv also
            //redirect to index page
            return View();
        }
        public IActionResult Edit(int id)
        {
            //get the emp form the list 
            //return to edit view 
            return View();
        }

        public IActionResult Delete(int id)
        {
            //return to the delete view 
            return View();

        }
        public IActionResult Del(int id)
        {
            if (id == 1)
            {
                //delete from the list 
                //update the csv file
            }
            return View();
        }
    }
}
