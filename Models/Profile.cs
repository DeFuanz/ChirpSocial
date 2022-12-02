using System.ComponentModel.DataAnnotations;

namespace Chirp.Models
{
    public class Profile //Model for Profile Data
    {
        public int ProfileID {get; set;} //Profile Primary Key

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string ProfileUserName {get; set;} = string.Empty;

        [StringLength(50, MinimumLength = 0)]
        public string ProfileBio {get; set;} = string.Empty;
        public List<Post> Posts {get; set;} = default!; //List of Users Posts
        public List<Reply> Replies {get; set;} = default!; //List of Users Replies
    }
}