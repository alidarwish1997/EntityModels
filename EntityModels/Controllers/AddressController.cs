using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityModels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public AddressController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        // GET: api/<AddressController>
        [HttpGet]
        public ActionResult<List<Address>> GetAllAddresses()
        {
            return appDbContext.Set<Address>().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Address> GetAddressById(int id)
        {
            var address = appDbContext.Set<Address>().Find(id);
            if (address == null)
            {
                return NotFound();
            }
            return address;
        }

        [HttpPost]
        public ActionResult<Address> CreateAddress(Address address)
        {
            appDbContext.Addresses.Add(address);
            appDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAddress(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }
            var existingAddress = appDbContext.Set<Address>().Find(id);
            if (existingAddress == null)
            {
                return NotFound();
            }
            existingAddress.Street = address.Street;
            existingAddress.BuildingNumber = address.BuildingNumber;
            existingAddress.City = address.City;
            existingAddress.Country = address.Country;
            existingAddress.State = address.State;
            existingAddress.DirectionNotes = address.DirectionNotes;
            appDbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(int id)
        {
            var address = appDbContext.Set<Address>().Find(id);
            if (address == null)
            {
                return NotFound();
            }
            appDbContext.Addresses.Remove(address);
            appDbContext.SaveChanges();
            return NoContent();
        }
    }
}