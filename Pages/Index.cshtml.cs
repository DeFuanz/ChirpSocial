﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Chirp.Models;

namespace ChirpSocial.Pages;

public class IndexModel : PageModel
{
    private readonly ChirpDbContext _context; //Left off adding drop down to select profile
    private readonly ILogger<IndexModel> _logger;
    public SelectList ProfileDropDown {get; set;} = default!;
    public List<Profile> profiles {get; set;} = default!;

    [BindProperty]
    [Required]
    public Profile profile {get; set;} = default!;
    public int SelectedProfileID {get; set;} 
    public IndexModel(ChirpDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        profiles = _context.Profiles.ToList();
        ProfileDropDown = new SelectList(profiles, "ProfileID", "ProfileUserName");
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("./Index");
    }
}
