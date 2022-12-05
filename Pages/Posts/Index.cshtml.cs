using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chirp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ChirpSocial.Pages_Posts
{
    public class IndexModel : PageModel //Shows all posts and which user is logged in
    {
        private readonly Chirp.Models.ChirpDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(Chirp.Models.ChirpDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Post> Post { get; set; } = default!;
        public Profile profile { get; set; } = default!;


        [BindProperty(SupportsGet = true)] //These two properties are for mantaining location is posts when paging
        public int PageNum { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        [BindProperty(SupportsGet = true)] //These two are for maintaining sorting type and user ID when reloading
        [Required]
        public string CurrentSort { get; set; }
        public int? CurrentUserID { get; set; }

        [BindProperty(SupportsGet = true)] //search bar properties
        public string? SearchString { get; set; }
        // public SelectList? Genres { get; set; }

        // [BindProperty(SupportsGet = true)]
        // public string? MovieGenre { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id, int? profileId)
        {

            _logger.LogWarning(SearchString);
            _logger.LogWarning(profileId.ToString());

            if (id == null && profileId != null) //is coming back from another page, set id to match profileId
            {
                id = profileId;
            }

            if (id != null && profileId == null) //if coming from landing page, set profileID to match.
            {
                profileId = id;
            }
            if (id == null && profileId == null) //if both null, send user to landing page to chose profile
            {
                _logger.LogWarning("redirecting problem");
                return RedirectToPage("/Index");
            }

            CurrentUserID = profileId;

            var fetchProfile = await _context.Profiles.Where(p => p.ProfileID == id).FirstOrDefaultAsync(); //No idea, but needed this to display profile name
            profile = fetchProfile;


            if (_context.Posts != null)
            {
                var query = _context.Posts.Select(p => p); //select all posts

                if (!string.IsNullOrEmpty(SearchString)) //check if search bar string is used
                {
                    query = query.Where(p => p.PostContent.Contains(SearchString));
                }

                switch (CurrentSort) //sort posts - date desc is defualted
                {
                    case "user_asc":
                        query = query.OrderBy(p => p.Profile.ProfileUserName);
                        break;
                    case "user_desc":
                        query = query.OrderByDescending(p => p.Profile.ProfileUserName);
                        break;
                    case "date_asc":
                        query = query.OrderBy(p => p.PostDate);
                        break;
                    case "date_desc":
                        query = query.OrderByDescending(p => p.PostDate);
                        break;
                    default:
                        query = query.OrderByDescending(p => p.PostDate);
                        break;
                }

                Post = await query.Skip((PageNum - 1) * PageSize).Take(PageSize) //generate posts based on sorting
                .Include(p => p.Profile).ToListAsync();
            }
            return Page();
        }
    }
}
