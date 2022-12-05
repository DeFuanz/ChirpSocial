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
    public class DetailsModel : PageModel
    {
        private readonly Chirp.Models.ChirpDbContext _context;

        public DetailsModel(Chirp.Models.ChirpDbContext context)
        {
            _context = context;
        }

        public Post Post { get; set; } = default!;

        public int? CurrentUserID {get; set;} //store user id to pass to other pages

        public async Task<IActionResult> OnGetAsync(int? id, int? profileId)
        {
            if (id == null || _context.Posts == null || profileId == null)
            {
                return NotFound();
            }

            CurrentUserID = profileId; //set current user to profileid to pass later
            var post = await _context.Posts.Include(m => m.Profile).Include(m => m.Replies).ThenInclude(m => m.Profile).FirstOrDefaultAsync(m => m.PostID == id);
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
    }
}
