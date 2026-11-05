using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Suteu_Razvan_Lab2.Data;
using Suteu_Razvan_Lab2.Models;

namespace Suteu_Razvan_Lab2.Pages.BorrowingPages;

public class EditModel : PageModel
{
    private readonly Suteu_Razvan_Lab2Context _context;

    public EditModel(Suteu_Razvan_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
        if (borrowing is null)
        {
            return NotFound();
        }
        Borrowing = borrowing;

        // Popularea listelor derulante cu Titlul cărții și Numele complet al membrului
        ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Reîncărcăm listele dacă validarea eșuează
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        _context.Attach(Borrowing).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BorrowingExists(Borrowing.ID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool BorrowingExists(int id)
    {
        return _context.Borrowing.Any(e => e.ID == id);
    }
}