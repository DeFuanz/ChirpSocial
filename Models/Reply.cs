

namespace Chirp.Models
{
    public class Reply
    {
        public int ReplyID {get; set;} //Reply 
        public string ReplyContent {get; set;} = string.Empty;
        public DateTime ReplyDate {get; set;}

        //User Navigation Properties
        public int ProfileID {get; set;}
        public Profile Profile {get; set;} = default!;

        //Post Navifation Properties
        public int PostID {get; set;}
        public Post Post {get; set;} = default!;
    }
}