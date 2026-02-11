using LibraryService.BL.Interfaces.Repositories;
using LibraryService.BL.Interfaces.Services;
using LibraryService.BL.Requests;
using LibraryService.Models.Models;

namespace LibraryService.BL.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task AddAsync(AddBookRequest request)
    {
        var book = new Book
        {
            Id = Guid.NewGuid().ToString(),
            Title = request.Title,
            Author = request.Author,
            IsBorrowed = false
        };

        await _bookRepository.AddAsync(book);
    }

    public async Task<List<Book>> GetAllAsync()
        => await _bookRepository.GetAllAsync();

    public async Task DeleteAsync(string id)
    {
        await _bookRepository.DeleteAsync(id);
    }

}
