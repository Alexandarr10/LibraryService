using LibraryService.BL.Interfaces.Repositories;
using LibraryService.BL.Interfaces.Services;

namespace LibraryService.BL.Services;

public class BorrowingService : IBorrowingService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMemberRepository _memberRepository;

    public BorrowingService(
        IBookRepository bookRepository,
        IMemberRepository memberRepository)
    {
        _bookRepository = bookRepository;
        _memberRepository = memberRepository;
    }

    public async Task BorrowBookAsync(string bookId, string memberId)
    {
        var book = await _bookRepository.GetByIdAsync(bookId)
            ?? throw new InvalidOperationException("Book not found");

        var member = await _memberRepository.GetByIdAsync(memberId)
            ?? throw new InvalidOperationException("Member not found");

        if (book.IsBorrowed)
            throw new InvalidOperationException("Book is already borrowed");

        book.IsBorrowed = true;
        await _bookRepository.UpdateAsync(book);
    }
}
