namespace Chirp.Models
{
    public class Post
    {
        public int PostID {get; set;}
        public DateTime PostDate {get; set;}
        public string PostContent {get; set;} = string.Empty;
        public List<Reply> Replies {get; set;} =default!;

        //Profile Navigation Properties
        public int ProfileID {get; set;}
        public Profile Profile {get; set;} = default!;

        //Replies Navigation Properties
        public int ReplyID {get; set;}
        public Reply Reply {get; set;} = default!;
    }
}