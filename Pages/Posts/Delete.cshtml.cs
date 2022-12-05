using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chirp.Models;

namespace ChirpSocial.Pages_Posts
{
    public class DeleteModel : PageModel //Delete post f user created it
    {
        private readonly Chirp.Models.ChirpDbContext _context;

        public int? CurrentUserId { get; set; } //store userID for later

        public DeleteModel(Chirp.Models.ChirpDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; } = default!; //store post info

        public async Task<IActionResult> OnGetAsync(int? id, int? profileId)
        {

            if (id == null || _context.Posts == null || profileId == null)
            {
                return RedirectToPage("/Index"); //redirect if user is not logged in
            }

            CurrentUserId = profileId; //re-store userid in property

            var post = await _context.Posts.FirstOrDefaultAsync(m => m.PostID == id); //grab post based on selected id

            var Profile = await _context.Profiles.Where(p => p.ProfileID == profileId).FirstOrDefaultAsync(); //grab profile to get all info

            if (post == null)
            {
                return NotFound();
            }
            else
            {
                Post = post;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int? profileId)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FindAsync(id); //find post to delete

            if (post != null) //delete post if found
            {
                Post = post;
                _context.Posts.Remove(Post);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { profileId = profileId }); //return to feed page after deleting
        }
    }
}
