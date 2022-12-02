using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Chirp.Models;

namespace ChirpSocial.Pages_Posts
{
    public class CreateModel : PageModel
    {
        private readonly Chirp.Models.ChirpDbContext _context;

        public CreateModel(Chirp.Models.ChirpDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProfileID"] = new SelectList(_context.Profiles, "ProfileID", "ProfileUserName");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Posts == null || Post == null)
            {
                return Page();
            }

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
