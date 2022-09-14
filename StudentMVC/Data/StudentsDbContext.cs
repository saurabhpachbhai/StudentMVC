using Microsoft.EntityFrameworkCore;
using StudentMVC.Models;

namespace StudentMVC.Data
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Students> Student { get; set; }
    }
}
