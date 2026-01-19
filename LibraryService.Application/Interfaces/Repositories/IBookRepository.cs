using LibraryService.Domain.Models;

namespace LibraryService.Application.Interfaces.Repositories;

public interface IBookRepository
{
    Task<Book?> GetByIdAsync(string id);
    Task<List<Book>> GetAllAsync();
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
}
