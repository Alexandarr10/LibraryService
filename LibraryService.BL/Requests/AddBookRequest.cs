namespace LibraryService.BL.Requests;

public class AddBookRequest
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
}
