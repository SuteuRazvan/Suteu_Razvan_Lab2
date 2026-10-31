
using Suteu_Razvan_Lab2.Models;
namespace Suteu_Razvan_Lab2.ViewModels 
{
    public class PublisherIndexData 
    { 
        public IEnumerable<Publisher> Publishers { get; set; } 
        public IEnumerable<Book> Books { get; set; } 
    } 
}