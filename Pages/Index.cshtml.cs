﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Chirp.Models;

namespace ChirpSocial.Pages;

public class IndexModel : PageModel //Landing page - requires profile seleciton to continue
{
    private readonly ChirpDbContext _context; 
    private readonly ILogger<IndexModel> _logger;
    public SelectList ProfileDropDown {get; set;} = default!;
    public List<Profile> profiles {get; set;} = default!;

    [BindProperty]
    [Required]
    public Profile profile {get; set;} = default!;
    
    public IndexModel(ChirpDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet() //List profiles to select
    {
        profiles = _context.Profiles.ToList();
        ProfileDropDown = new SelectList(profiles, "ProfileID", "ProfileUserName"); 
    }

    public IActionResult OnPost() //Verify profile and continue to feed
    {
        var tempProfile = _context.Profiles.Find(profile.ProfileID);
        if (tempProfile == null)
        {
            return Page();
        }
        profile = tempProfile;
        _logger.LogWarning("Going to new page");

        
        return RedirectToPage("/Posts/Index", new {id = profile.ProfileID}); 
    }
}
