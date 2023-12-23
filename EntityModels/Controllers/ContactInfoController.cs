using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityModels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public ContactInfoController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        // GET: api/<ContactInfoController>
        [HttpGet]
        public ActionResult<List<ContactInfo>> GetAllContacts()
        {
            return appDbContext.Contacts.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ContactInfo> GetContactInfoById(int id)
        {
            var contact = appDbContext.Contacts.Find( id);
            if (contact == null)
            {
                return NotFound();
            }
            return contact;
        }

        [HttpPost]
        public ActionResult<ContactInfo> CreateContactInfo(ContactInfo contact)
        {
            appDbContext.Contacts.Add(contact);
            appDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetContactInfoById), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateContactInfo(int id, ContactInfo contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }
            var existingContactInfo = appDbContext.Contacts.Find(id);
            if (existingContactInfo == null)
            {
                return NotFound();
            }
            existingContactInfo.Address = contact.Address;
            existingContactInfo.PersonalEmail = contact.PersonalEmail;
            existingContactInfo.WorkEmail = contact.WorkEmail;
            existingContactInfo.MobilePhone = contact.MobilePhone;
            existingContactInfo.OtherPhone = contact.OtherPhone;
            appDbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContactInfo(int id)
        {
            var contact = appDbContext.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            appDbContext.Contacts.Remove(contact);
            appDbContext.SaveChanges();
            return NoContent();
        }
    }
}