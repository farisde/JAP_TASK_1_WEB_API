using JAP_TASK_1_WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace JAP_TASK_1_WEB_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<CastMember> CastMembers { get; set; }
    }
}