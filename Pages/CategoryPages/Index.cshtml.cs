using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suteu_Razvan_Lab2.Models;
using Suteu_Razvan_Lab2.ViewModels;

namespace Suteu_Razvan_Lab2.Pages.CategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly Suteu_Razvan_Lab2Context _context;

        public IndexModel(Suteu_Razvan_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();

            // Preluăm categoriile împreună cu legăturile spre cărți și autorii lor
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                    .ThenInclude(c => c.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();

                // Extragem cărțile asociate categoriei selectate
                CategoryData.Books = category.BookCategories.Select(s => s.Book);
            }
        }
    }
}