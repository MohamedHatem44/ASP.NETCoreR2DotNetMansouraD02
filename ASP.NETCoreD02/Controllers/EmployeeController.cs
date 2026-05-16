using ASP.NETCoreD02.Models;
using ASP.NETCoreD02.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreD02.Controllers
{
    public class EmployeeController : Controller
    {
        /*------------------------------------------------------------------*/
        // Context db = new Context();
        // Context db;

        // ctor
        /*------------------------------------------------------------------*/
        // DataBase
        static List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, Name = "Ahmed", Age = 26 , Salary = 1234 },
            new Employee { Id = 2, Name = "Mohamed", Age = 36 , Salary = 2234 },
            new Employee { Id = 3, Name = "Sara", Age = 46 , Salary = 4234 },
            new Employee { Id = 4, Name = "Omar", Age = 25 , Salary = 5234 },
            new Employee { Id = 5, Name = "Ali", Age = 23 , Salary = 6234 },
            new Employee { Id = 6, Name = "Mai", Age = 36 , Salary = 7234 },
            new Employee { Id = 7, Name = "Ramy", Age = 49 , Salary = 8234 },
            new Employee { Id = 8, Name = "Hamada", Age = 18 , Salary = 9234 },
            new Employee { Id = 9, Name = "Hatem", Age = 26 , Salary = 10234 },
            new Employee { Id = 10, Name = "Osama", Age = 25 , Salary = 17234 },
        };
        /*------------------------------------------------------------------*/
        //// Get All Employees
        //public IActionResult Index()
        //{
        //    //// Return View Name Index, Model = null 
        //    //return View();

        //    //// Return View Name Index, Model = employees 
        //    //return View(employees);

        //    //// Retun View Name GetAll, Model = null
        //    //return View("GetAll");

        //    // Retun View Name GetAll, Model = employees
        //    return View("GetAll", employees);
        //}
        ///*------------------------------------------------------------------*/
        //public IActionResult GetAll()
        //{
        //    // Return Data Not in Model
        //    // PageName
        //    // Style
        //    // etc
        //    // List of Departments

        //    //IDictionary<string, object?>
        //    // Set Data in ViewData
        //    ViewData[Constant.PageTitle] = "Employees List";
        //    ViewData["PageTitle"] = "Employees List 1";

        //    ViewBag.PageTitle2 = "Employees List 2";
        //    ViewBag.PageTitle = "Hamada"; // => ViewData["PageTitle"] = "Hamada";

        //    return View(employees);
        //}
        ///*------------------------------------------------------------------*/
        //public IActionResult GetById(int id)
        //{
        //    // Domain Model
        //    var employeeInDB = employees.FirstOrDefault(e => e.Id == id);
        //    if (employeeInDB is null)
        //    {
        //        return NotFound();
        //    }

        //    // Mapping
        //    // From Domain Model to ViewModel
        //    // Manual
        //    // AutoMapper
        //    EmployeeReadVM employeeReadVM = new EmployeeReadVM
        //    {
        //        Id = employeeInDB.Id,
        //        Name = employeeInDB.Name,
        //        Age = employeeInDB.Age,
        //        Salary = employeeInDB.Salary,

        //        PageTitle1 = "Page Title 1",
        //        PageTitle2 = "Page Title 2",
        //        PageTitle3 = "Page Title 3"
        //    };

        //    return View(employeeReadVM);
        //}
        /*------------------------------------------------------------------*/
        // Get All Employees
        public IActionResult Index()
        {
            // To Do Return Employee ReadVM List
            return View(employees);
        }
        /*------------------------------------------------------------------*/
        public IActionResult GetById(int id)
        {
            // Domain Model
            var employeeInDB = employees.FirstOrDefault(e => e.Id == id);
            if (employeeInDB is null)
            {
                return NotFound();
            }

            EmployeeReadVM employeeReadVM = new EmployeeReadVM
            {
                Id = employeeInDB.Id,
                Name = employeeInDB.Name,
                Age = employeeInDB.Age,
                Salary = employeeInDB.Salary,

                PageTitle1 = "Page Title 1",
                PageTitle2 = "Page Title 2",
                PageTitle3 = "Page Title 3"
            };

            return View(employeeReadVM);
        }
        /*------------------------------------------------------------------*/
        // Will Send View To Create New Employee
        public IActionResult Create()
        {
            return View();
        }
        /*------------------------------------------------------------------*/
        // Model Binding => Bind Data From Request To Action Parameters
        // V01
        public IActionResult ActualCreateV01(int id, string name, int age, decimal salary)
        {
            // To Do Create New Employee
            // Add To DataBase
            // Return

            var newEmployee = new Employee
            {
                Id = id,
                Name = name,
                Age = age,
                Salary = salary
            };

            employees.Add(newEmployee);
            //return RedirectToAction("Index");
            return RedirectToAction(nameof(Index));
        }
        /*------------------------------------------------------------------*/
        // Model Binding => Bind Data From Request To Action Parameters
        // V02
        public IActionResult ActualCreateV02(Employee employee)
        {
            employees.Add(employee);
            return RedirectToAction(nameof(Index));
        }
        /*------------------------------------------------------------------*/
        // Will Send View To Edit New Employee
        public IActionResult Edit(int id)
        {
            var employeeInDB = employees.FirstOrDefault(e => e.Id == id);
            if (employeeInDB is null)
            {
                return NotFound();
            }
            return View(employeeInDB);
        }
        /*------------------------------------------------------------------*/
        public IActionResult ActualEdit(Employee employee)
        {
            var employeeInDB = employees.FirstOrDefault(e => e.Id == employee.Id);
            if (employeeInDB is null)
            {
                return NotFound();
            }
            // Update => Full Replacment

            var Nemployee = new Employee
            {
                Id = employee.Id,
                Name = employee.Name,
            };
            // Update

            // Validations 
            employeeInDB.Name = employee.Name;
            employeeInDB.Age = employee.Age;
            employeeInDB.Salary = employee.Salary; // 0

            return RedirectToAction(nameof(Index));
        }
        /*------------------------------------------------------------------*/
        public IActionResult Delete(int id)
        {
            var employeeInDB = employees.FirstOrDefault(e => e.Id == id);
            if (employeeInDB is null)
            {
                return NotFound();
            }
            employees.Remove(employeeInDB);
            return RedirectToAction(nameof(Index));
        }
        /*------------------------------------------------------------------*/
    }
}
