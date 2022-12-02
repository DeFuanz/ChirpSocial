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
                    new Profile //1
                    {
                        ProfileUserName = "John DeFore",
                        ProfileBio = "Founder of Chirp Social"
                    },
                    new Profile //2
                    {
                        ProfileUserName = "Kareem Dana",
                        ProfileBio = "Quality Assurance for Chirp Social"
                    },
                    new Profile //3
                    {
                        ProfileUserName = "King Henry",
                        ProfileBio = "You already know who I am"
                    },
                    new Profile //4
                    {
                        ProfileUserName = "Napoleon Bonaparte",
                        ProfileBio = "There wasn't a height requirement so I joined"
                    },
                    new Profile //5
                    {
                        ProfileUserName = "Muhammad Ali",
                        ProfileBio = "Just rolling with the punches"
                    },
                    new Profile //6
                    {
                        ProfileUserName = "William Shakespeare",
                        ProfileBio = "To be on not to be here"
                    },
                    new Profile //7
                    {
                        ProfileUserName = "Stevie Wonder",
                        ProfileBio = "I don't see the point of this platform"
                    },
                    new Profile //8
                    {
                        ProfileUserName = "Isaac Newton",
                        ProfileBio = "I'm more of an android guy"
                    }
                );

                context.SaveChanges();

                context.Posts.AddRange(
                    new Post //1
                    {
                        PostContent = "Welcome everyone",
                        PostDate = DateTime.Now,
                        ProfileID = 1,
                        Replies = new List<Reply>
                        {
                            new Reply
                            {
                                ReplyContent = "Glad to be here",
                                ReplyDate = DateTime.Now,
                                ProfileID = 3,
                            },
                            new Reply
                            {
                                ReplyContent = "Chirp Chirp",
                                ReplyDate = DateTime.Now,
                                ProfileID = 4
                            }
                        }
                    },
                    new Post //2
                    {
                        PostContent = "Only 28 Characters?",
                        PostDate = DateTime.Now,
                        ProfileID = 3,
                        Replies = new List<Reply>
                        {
                            new Reply
                            {
                                ReplyContent = "Don't need more",
                                ReplyDate = DateTime.Now,
                                ProfileID = 5
                            },
                            new Reply
                            {
                                ReplyContent = "you're 28 characters",
                                ReplyDate = DateTime.Now,
                                ProfileID = 6
                            }
                        }
                    },
                    new Post //3
                    {
                        PostContent = "The computer is dying on me.",
                        PostDate = DateTime.Now,
                        ProfileID = 4,
                        Replies = new List<Reply>
                        {
                            new Reply
                            {
                                ReplyContent = "Give it CPR!",
                                ReplyDate = DateTime.Now,
                                ProfileID = 7
                            },
                            new Reply
                            {
                                ReplyContent = "Terrible!",
                                ReplyDate = DateTime.Now,
                                ProfileID = 8
                            }
                        }
                    },
                    new Post //4
                    {
                        PostContent = "Good morning!",
                        PostDate = DateTime.Now,
                        ProfileID = 5,
                        Replies = new List<Reply>
                        {
                            new Reply
                            {
                                ReplyContent = "Morning!",
                                ReplyDate = DateTime.Now,
                                ProfileID = 1
                            },
                            new Reply
                            {
                                ReplyContent = "No",
                                ReplyDate = DateTime.Now,
                                ProfileID = 3
                            }
                        }
                    },
                    new Post //5
                    {
                        PostContent = "I broke my phone.",
                        PostDate = DateTime.Now,
                        ProfileID = 6,
                        Replies = new List<Reply>
                        {
                            new Reply
                            {
                                ReplyContent = "Thats not good!",
                                ReplyDate = DateTime.Now,
                                ProfileID = 4
                            },
                            new Reply
                            {
                                ReplyContent = "Oh No!",
                                ReplyDate = DateTime.Now,
                                ProfileID = 5
                            }
                        }
                    },
                    new Post //6
                    {
                        PostContent = "Simple Test Post",
                        PostDate = DateTime.Now,
                        ProfileID = 7
                    },
                    new Post //7
                    {
                        PostContent = "How dare you!",
                        PostDate = DateTime.Now,
                        ProfileID = 8
                    },
                    new Post //8
                    {
                        PostContent = "Who's Archibald?",
                        PostDate = DateTime.Now,
                        ProfileID = 1
                    },
                    new Post //9
                    {
                        PostContent = "Welcome Professor Dana",
                        PostDate = DateTime.Now,
                        ProfileID = 2
                    },
                    new Post //10
                    {
                        PostContent = "Random Sentences",
                        PostDate = DateTime.Now,
                        ProfileID = 3
                    },
                    new Post //11
                    {
                        PostContent = "Check Blackboard",
                        PostDate = DateTime.Now,
                        ProfileID = 4
                    },
                    new Post //12
                    {
                        PostContent = "I love this platform",
                        PostDate = DateTime.Now,
                        ProfileID = 5
                    },
                    new Post //13
                    {
                        PostContent = "Is it on?",
                        PostDate = DateTime.Now,
                        ProfileID = 6
                    },
                    new Post //14
                    {
                        PostContent = "C# is the greatest",
                        PostDate = DateTime.Now,
                        ProfileID = 7
                    },
                    new Post //15
                    {
                        PostContent = "Im more of a java guy",
                        PostDate = DateTime.Now,
                        ProfileID = 8
                    },
                    new Post //16
                    {
                        PostContent = "Its all the same",
                        PostDate = DateTime.Now,
                        ProfileID = 1
                    },
                    new Post //17
                    {
                        PostContent = "is twitter dead?",
                        PostDate = DateTime.Now,
                        ProfileID = 3
                    },
                    new Post //18
                    {
                        PostContent = "More random stuff",
                        PostDate = DateTime.Now,
                        ProfileID = 4
                    },
                    new Post //19
                    {
                        PostContent = "im out of things to say",
                        PostDate = DateTime.Now,
                        ProfileID = 5
                    },
                    new Post //20
                    {
                        PostContent = "only five to go",
                        PostDate = DateTime.Now,
                        ProfileID = 6
                    },
                    new Post //21
                    {
                        PostContent = "four more?",
                        PostDate = DateTime.Now,
                        ProfileID = 7
                    },
                    new Post //22
                    {
                        PostContent = "three!",
                        PostDate = DateTime.Now,
                        ProfileID = 8
                    },
                    new Post //23
                    {
                        PostContent = "two can be as bad as one",
                        PostDate = DateTime.Now,
                        ProfileID = 9
                    },
                    new Post //24
                    {
                        PostContent = "and done",
                        PostDate = DateTime.Now,
                        ProfileID = 1
                    },
                    new Post //25
                    {
                        PostContent = "nevermind, now i am",
                        PostDate = DateTime.Now,
                        ProfileID = 3
                    }
                );
                context.SaveChanges();
            }
        }
    }
}