using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Suteu_Razvan_Lab2.Data;
using Suteu_Razvan_Lab2.Models;

namespace Suteu_Razvan_Lab2.Pages.BorrowingPages;

public class CreateModel : PageModel
{
    private readonly Suteu_Razvan_Lab2Context _context;

    public CreateModel(Suteu_Razvan_Lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
        return Page();
    }

    [BindProperty]
    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        _context.Borrowing.Add(Borrowing);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}