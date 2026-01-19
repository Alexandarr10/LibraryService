namespace LibraryService.Models.Models;

public class Book
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public bool IsBorrowed { get; set; }
}
