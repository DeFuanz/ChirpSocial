

namespace Chirp.Models
{
    public class Reply //Model for Reply data
    {
        public int ReplyID {get; set;} //Reply Primary Key
        public string ReplyContent {get; set;} = string.Empty;
        public DateTime ReplyDate {get; set;}

        //User Navigation Properties
        public int ProfileID {get; set;}
        public Profile? Profile {get; set;}

        //Post Navifation Properties
        public int PostID {get; set;}
        public Post? Post {get; set;}
    }
}