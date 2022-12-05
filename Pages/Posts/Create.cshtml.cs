using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Chirp.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ChirpSocial.Pages_Posts
{
    public class CreateModel : PageModel
    {
        private readonly Chirp.Models.ChirpDbContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(Chirp.Models.ChirpDbContext context, ILogger<CreateModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        public DateTime PostDateToday = DateTime.Now;
        public int? CurrentUserID { get; set; }
        public Profile? profile { get; set; }

        public async Task<IActionResult> OnGet(int? profileId)
        {
            if (profileId == null)
            {
                return RedirectToPage("/Index");
            }

            profile = await _context.Profiles.Where(p => p.ProfileID == profileId).FirstOrDefaultAsync();

            CurrentUserID = profileId;

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? profileId)
        {

            if (!ModelState.IsValid || _context.Posts == null || Post == null || profileId == null)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                foreach (var e in errors)
                {
                    _logger.LogWarning(e.ErrorMessage);
                }
                return Page();
            }
            
            

            Post.PostDate = PostDateToday;
            Post.ProfileID = profileId.GetValueOrDefault();

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new {profileId = profileId});
        }
    }
}
