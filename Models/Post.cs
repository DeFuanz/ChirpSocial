using System.ComponentModel.DataAnnotations;

namespace Chirp.Models
{
    public class Post //Model for Post Data
    {
        public int PostID {get; set;} //Post Primary Key
        
        [Display(Name = "Date")]
        public DateTime PostDate {get; set;} 

        [Required]
        [Display(Name = "Post")]
        [StringLength(28, MinimumLength = 1)]
        public string PostContent {get; set;} = string.Empty;
        public List<Reply>? Replies {get; set;} = default!;

        //Profile Navigation Properties
        public int ProfileID {get; set;}

        [Display(Name = "User")]
        public Profile? Profile {get; set;}
    }
}