using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suteu_Razvan_Lab2;
using Suteu_Razvan_Lab2.Models;

namespace Suteu_Razvan_Lab2.Pages.BookPages
{
    public class DetailsModel : PageModel
    {
        private readonly Suteu_Razvan_Lab2Context _context;

        public DetailsModel(Suteu_Razvan_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Includem Publisher-ul, Autorul și Categoriile
            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                    .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}