using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityModels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public JobController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        // GET: api/<JobController>
        [HttpGet]
        public ActionResult<List<Job>> GetAllJobs()
        {
            return appDbContext.Jobs.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Job> GetJobById(int id)
        {
            var Job = appDbContext.Jobs.Find(id);
            if (Job == null)
            {
                return NotFound();
            }
            return Job;
        }
        [HttpPost]
        public ActionResult<Job> CreateJob(Job job)
        {
            appDbContext.Jobs.Add(job);
            appDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateJob(int id, Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }
            var existingJob = appDbContext.Jobs.Find(id);
            if (existingJob == null)
            {
                return NotFound();
            }
            existingJob.Name = job.Name;
            existingJob.DateCreated = job.DateCreated;
            appDbContext.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteJob(int id)
        {
            var job = appDbContext.Jobs.ToList().Find(j => j.Id == id);
            if (job == null)
            {
                return NotFound();
            }
            appDbContext.Jobs.ToList().Remove(job);
            appDbContext.SaveChanges();
            return NoContent();
        }
    }
}


   