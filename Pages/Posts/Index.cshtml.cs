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
    public class IndexModel : PageModel
    {
        private readonly Chirp.Models.ChirpDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(Chirp.Models.ChirpDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Post> Post { get;set; } = default!;
        public Profile profile {get; set;} = default!;
        

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;

        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id, int? profileId)
        {


            if (id == null && profileId == null) //if both null, send user to landing page to chose profile
            {
                return RedirectToPage("/Index");
            }

            if (id == null && profileId != null) //is coming back from another page, set id to match profileId
            {
                id = profileId;
            }

            if (id != null && profileId == null) //if coming from landing page, set profileID to match.
            {
                profileId = id;
            }

            var fetchProfile = await _context.Profiles.Where(p => p.ProfileID == id).FirstOrDefaultAsync();
            profile = fetchProfile;
            
            _logger.LogWarning(profile.ProfileID.ToString());

            if (_context.Posts != null)
            {
                var query = _context.Posts.Select(p => p);

                switch(CurrentSort)
                {
                    case "user_asc":
                        query = query.OrderBy(p => p.Profile.ProfileUserName);
                        break;
                    case "user_desc":
                        query = query.OrderByDescending(p => p.Profile.ProfileUserName);
                        break;
                }

                Post = await query.Skip((PageNum -1)*PageSize).Take(PageSize)
                .Include(p => p.Profile).ToListAsync();
            }
            return Page();
        }
    }
}
