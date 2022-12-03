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

        public IndexModel(Chirp.Models.ChirpDbContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;

        public async Task OnGetAsync()
        {
            if (_context.Posts != null)
            {
                Post = await _context.Posts.Skip((PageNum -1)*PageSize).Take(PageSize)
                .Include(p => p.Profile).ToListAsync();
            }
        }
    }
}
