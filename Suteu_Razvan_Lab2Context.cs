using Microsoft.EntityFrameworkCore;
using Suteu_Razvan_Lab2.Models;

namespace Suteu_Razvan_Lab2.Data
{
    public class Suteu_Razvan_Lab2Context : DbContext
    {
        public Suteu_Razvan_Lab2Context(DbContextOptions<Suteu_Razvan_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Suteu_Razvan_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Suteu_Razvan_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Suteu_Razvan_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Suteu_Razvan_Lab2.Models.Category> Categories { get; set; } = default!;
    }
}