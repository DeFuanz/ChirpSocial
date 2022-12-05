using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chirp.Models;
using System.ComponentModel.DataAnnotations;

namespace ChirpSocial.Pages_Posts
{
    public class DetailsModel : PageModel //View a post with all its details including replies and reply details
    {
        private readonly Chirp.Models.ChirpDbContext _context;
        private readonly ILogger<DetailsModel> _logger;

        public DetailsModel(Chirp.Models.ChirpDbContext context, ILogger<DetailsModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public Post Post { get; set; } = default!; //store grabbed post

        [BindProperty]
        [Required]
        public Reply Reply { get; set; } = default!; //store a new reply

        public int? CurrentUserID { get; set; } //store user id to pass to other pages
        public DateTime ReplyDateToday = DateTime.Now; //store todays date and time for new reply

        public async Task<IActionResult> OnGetAsync(int? id, int? profileId)
        {
            if (id == null || _context.Posts == null || profileId == null) //redirect to landing page if not logged in
            {
                return RedirectToPage("/Index");
            }

            CurrentUserID = profileId; //set current user to profileid to pass later

            var post = await _context.Posts.Include(m => m.Profile).Include(m => m.Replies).ThenInclude(m => m.Profile).FirstOrDefaultAsync(m => m.PostID == id); //grab post selected from feed

            if (post == null) //verify post is found
            {
                return NotFound();
            }
            else
            {
                Post = post;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? profileId, int? postId)
        {
            if (profileId == null || postId == null) //make sure required ids are passed or return to login
            {
                return RedirectToPage("/Index");
            }

            Reply.ReplyDate = ReplyDateToday; //override reply date to today
            Reply.ProfileID = profileId.GetValueOrDefault(); //override reply id to logged in user
            Reply.PostID = postId.GetValueOrDefault(); //link reply to post via post id

            _logger.LogWarning($"{Reply.ReplyContent} {Reply.ReplyDate} {Reply.ProfileID} {Reply.PostID}"); //for my sanity

            _context.Replies.Add(Reply); //add post
            await _context.SaveChangesAsync(); //save

            return RedirectToPage("./Details", new {profileId = profileId, id = postId}); //reload same page to view new comments
        }
    }
}

