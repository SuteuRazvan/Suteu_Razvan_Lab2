using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suteu_Razvan_Lab2.Models;
using Suteu_Razvan_Lab2;

namespace Suteu_Razvan_Lab2.Pages.AuthorPages;

public class IndexModel : PageModel
{
    private readonly Suteu_Razvan_Lab2Context _context;

    public IndexModel(Suteu_Razvan_Lab2Context context)
    {
        _context = context;
    }

    public IList<Author> Author { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Author = await _context.Author.ToListAsync();
    }
}
