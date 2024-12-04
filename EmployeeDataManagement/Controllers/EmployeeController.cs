using EmployeeDataManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDataManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        public EmployeeController(ApplicationContext applicationContext)
        {
            this._applicationContext = applicationContext;
        }

        public IActionResult Index()
        {
            var employees = _applicationContext.Employees.ToList();
            return View(employees);

           
        }
        
        [HttpGet]
        

        public IActionResult Create()
        {
            return View();
        }
       


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            //if (ModelState.IsValid)
            {
                _applicationContext.Employees.Add(employee);
                _applicationContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = _applicationContext.Employees.Find(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            //if (ModelState.IsValid)
            {
                _applicationContext.Entry(employee).State = EntityState.Modified;
                _applicationContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = _applicationContext.Employees.Find(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = _applicationContext.Employees.Find(id);
            _applicationContext.Employees.Remove(employee);
            _applicationContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
