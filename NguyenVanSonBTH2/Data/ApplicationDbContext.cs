using NguyenVanSonBTH2.Models;
using Microsoft.EntityFrameworkCore;


namespace NguyenVanSonBTH2.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
        }
        public DbSet<Student>Students {get; set;}
        public DbSet<NguyenVanSonBTH2.Models.Employee> Employee { get; set;}
    }
}