using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityModels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public EmployeeController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            return appDbContext.Employees.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = appDbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            appDbContext.Employees.Add(employee);
            appDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            var existingEmployee = appDbContext.Employees.Find(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.MiddleName = employee.MiddleName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.ContactInfo = employee.ContactInfo;
            existingEmployee.Age = employee.Age;
            existingEmployee.HireDate = employee.HireDate;
            existingEmployee.Department = employee.Department;
            existingEmployee.JobDescription = employee.JobDescription;
            existingEmployee.MonthlySalary = employee.MonthlySalary;
            existingEmployee.ManagerId = employee.ManagerId;
            appDbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = appDbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            appDbContext.Employees.Remove(employee);
            appDbContext.SaveChanges();
            return NoContent();
        }
    }
}

