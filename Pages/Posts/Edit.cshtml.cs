using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chirp.Models;

namespace ChirpSocial.Pages_Posts
{
    public class EditModel : PageModel
    {
        private readonly Chirp.Models.ChirpDbContext _context;

        public EditModel(Chirp.Models.ChirpDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        public DateTime PostDateToday = DateTime.Now;
        public int? CurrentUserID { get; set; }
        public Profile? profile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? profileId)
        {
            if (id == null || _context.Posts == null || profileId == null)
            {
                return RedirectToPage("/Index");
            }

            CurrentUserID = profileId;

            var post =  await _context.Posts.FirstOrDefaultAsync(m => m.PostID == id);
            if (post == null)
            {
                return NotFound();
            }
            
            profile = await _context.Profiles.Where(p => p.ProfileID == profileId).FirstOrDefaultAsync();

            Post = post;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? profileId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Post.PostDate = PostDateToday;
            Post.ProfileID = profileId.GetValueOrDefault();

            _context.Attach(Post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(Post.PostID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new {profileId = profileId});
        }

        private bool PostExists(int id)
        {
          return (_context.Posts?.Any(e => e.PostID == id)).GetValueOrDefault();
        }
    }
}
