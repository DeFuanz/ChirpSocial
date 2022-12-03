using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Chirp.Models;

namespace ChirpSocial.Pages;

public class IndexModel : PageModel
{
    private readonly ChirpDbContext _context; //Left off adding drop down to select profile
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
