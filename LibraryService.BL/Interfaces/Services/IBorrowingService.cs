namespace LibraryService.BL.Interfaces.Services;

public interface IBorrowingService
{
    Task BorrowBookAsync(string bookId, string memberId);
}
