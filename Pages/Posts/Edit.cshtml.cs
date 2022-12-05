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
    public class EditModel : PageModel //Allows for posts to be edited with new content and new datetime
    {
        private readonly Chirp.Models.ChirpDbContext _context;

        public EditModel(Chirp.Models.ChirpDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        public DateTime PostDateToday = DateTime.Now; //store todays datetime to update on new post
        public int? CurrentUserID { get; set; } //store User ID for redirecting and updating posts
        public Profile? profile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? profileId)
        {
            if (id == null || _context.Posts == null || profileId == null) //redirect to landing if not logged in
            {
                return RedirectToPage("/Index");
            }

            CurrentUserID = profileId; //store userID

            var post =  await _context.Posts.FirstOrDefaultAsync(m => m.PostID == id); //grab post that was selected
            if (post == null)
            {
                return NotFound();
            }
            
            profile = await _context.Profiles.Where(p => p.ProfileID == profileId).FirstOrDefaultAsync(); //grab profile to get profile info

            Post = post; //store grabbed post into property

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

            //updating these here to avoid showing them on the front end
            Post.PostDate = PostDateToday; //override date as todays date before updateing
            Post.ProfileID = profileId.GetValueOrDefault(); //override profile id before updating

            _context.Attach(Post).State = EntityState.Modified; //update post

            try //update or throw exception
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

            return RedirectToPage("./Index", new {profileId = profileId}); //go back to feed page after update
        }

        private bool PostExists(int id) //shorter query for checking if exists above
        {
          return (_context.Posts?.Any(e => e.PostID == id)).GetValueOrDefault();
        }
    }
}
