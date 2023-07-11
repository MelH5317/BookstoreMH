namespace BookstoreMH.Data;

public class Book
{
    public int BookId { get; set; }
    public required string Author { get; set; }
    public required string Title { get; set; }
    public required string Price { get; set; }

}
