using Microsoft.EntityFrameworkCore;

namespace Chirp.Models
{
    public class ChirpDbContext : DbContext
    {
        public ChirpDbContext (DbContextOptions<ChirpDbContext> options) : base(options)
        {
        }

        //data sets
        public DbSet<Profile> Profiles {get; set;} = default!;
        public DbSet<Post> Posts {get; set;} = default!;
        public DbSet<Reply> Replies {get; set;} = default!;
    }
}