using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookstoreMH.Models
{
    public class EditBookCommand
    {
        [Required, DisplayName("Author")]
        public string Author { get; set; }
        
        [Required, DisplayName("Title")]
        public string Title { get; set; }

        [Required, DisplayName("Price")]
        public double Price { get; set; }
    }
}
