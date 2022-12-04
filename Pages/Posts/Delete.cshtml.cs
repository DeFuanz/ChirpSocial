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
    public class DeleteModel : PageModel
    {
        private readonly Chirp.Models.ChirpDbContext _context;

        public int? CurrentUserId {get; set;}

        public DeleteModel(Chirp.Models.ChirpDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, int? profileId)
        {

            if (id == null || _context.Posts == null || profileId == null)
            {
                return NotFound();
            }

            CurrentUserId = profileId;

            var post = await _context.Posts.FirstOrDefaultAsync(m => m.PostID == id);

            var Profile = await _context.Profiles.Where(p => p.ProfileID == profileId).FirstOrDefaultAsync();

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
            var post = await _context.Posts.FindAsync(id);

            if (post != null)
            {
                Post = post;
                _context.Posts.Remove(Post);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new {profileId = profileId});
        }
    }
}
