using System.ComponentModel.DataAnnotations.Schema;

namespace Suteu_Razvan_Lab2.Models
{
    [Table("Categories")] // Dacă în SQL Server tabelul tău se numește exact așa
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}