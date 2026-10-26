<<<<<<< HEAD
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
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suteu_Razvan_Lab2.Models;
using Suteu_Razvan_Lab2.Data;

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
            if (id is null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (book is null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }

            return Page();
        }
    }
>>>>>>> 84d784c7711dbcb0383c826d1c4a548e251855b9
}