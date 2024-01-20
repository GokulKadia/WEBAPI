using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Data
{
    public class ApiDBContext:DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options):base (options)
        {

        }
        public DbSet<Customer> customers { get; set; }


    }
}
