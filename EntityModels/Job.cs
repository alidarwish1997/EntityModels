using Microsoft.EntityFrameworkCore;

namespace EntityModels
{
    public class Job
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
