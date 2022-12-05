# ChirpSocial
When Twitter Fails, Chirp Prevails

Chirp is a Mock-twitter style web-app created with razorpages as a school project.

**How Chirp Works**
The project requires the user to select a profile from the landing page. After selection, the pages continue to pass around a "profileId" as the user navigates through the feed, new post, delete, and post details pages. This allows the user to make new posts, access edit and delete for only their posts, as well as leave comments under their name without needing to manually select or input their profile information.

The user can:
- View all posts (default: newest to oldest)
- Sort posts
- search posts
- Create new posts
- View post details (post and all its commments)
- reply to a post
- edit/delete their own posts

**Lessons Learned**
As the project scaled I quickly ran into project creep as well as getting lines of codes less organized as well as html and bootstrap elements mixed in that may not even do anything (ex: using too many divs or irrelevant class tags). With the project creep, i kept adding features only to realize i wanted to add other features, or change where the features located/how they worked. Overall, I started to get less organized as the project grew more complex. For future projects, I need to plan accordingly as well as keep code combined in chunks that are relevant to each other for easier reading. 

**Going Forward**
The project is not at all perfect. With that, I would really like to continue working on is to expand my knowledge with ASP.NET. This includes, but not limited to:
- Cleaning and Organizing the Code
- Learning and implementing authentication to replace passing user id variables
- Relocating some features such as the new post function to go under the profile area on the feed page
- Reply count indicators on each post to show how many replies it has before clicking on in.
- More to be added
