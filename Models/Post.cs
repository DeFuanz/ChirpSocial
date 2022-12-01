namespace Chirp.Models
{
    public class Post //Model for Post Data
    {
        public int PostID {get; set;} //Post Primary Key
        public DateTime PostDate {get; set;}
        public string PostContent {get; set;} = string.Empty;
        public List<Reply> Replies {get; set;} =default!;

        //Profile Navigation Properties
        public int ProfileID {get; set;}
        public Profile? Profile {get; set;}
    }
}