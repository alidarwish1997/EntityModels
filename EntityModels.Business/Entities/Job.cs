using Microsoft.EntityFrameworkCore;

namespace EntityModels.Core.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
