using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityModels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public CustomerController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            return appDbContext.Customers.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = appDbContext.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            appDbContext.Customers.Add(customer);
            appDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            var existingCustomer = appDbContext.Customers.Find(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.MiddleName = customer.MiddleName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.ContactInfo = customer.ContactInfo;
            existingCustomer.Age = customer.Age;
            existingCustomer.AccountNumber = customer.AccountNumber;
            appDbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = appDbContext.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            appDbContext.Customers.Remove(customer);
            appDbContext.SaveChanges();
            return NoContent();
        }
    }
}