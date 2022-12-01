using Microsoft.EntityFrameworkCore;

namespace Chirp.Models
{
    public static class SeedData // starting seed data
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ChirpDbContext(serviceProvider.GetRequiredService<DbContextOptions<ChirpDbContext>>()))
            {
                if (context.Posts.Any())
                {
                    return;
                }

                context.Profiles.AddRange( 
                    //I was unsure how to layer the seeded data, my first thoughts are profile, then post, then reply but im not sure how it would capture the
                    // ID from another profile unless i were to restructure my database.
                    new Profile
                    {
                        ProfileUserName = "John DeFore",
                        ProfileBio = "Founder of Chirp Social",
                        Posts = new List<Post> 
                        {
                            new Post
                            {
                                PostContent = "Welcome to Chirp! This is the First Chirp!",
                                PostDate = DateTime.Today,
                                Replies = new List<Reply>
                                {
                                    new Reply
                                    {
                                        ReplyContent = "This is the greatest platform ever!",
                                        ReplyDate = DateTime.Today
                                    }
                                }
                            }
                        }
                    }
                )
            }
        }
    }
}