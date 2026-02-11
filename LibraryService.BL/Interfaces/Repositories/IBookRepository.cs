using LibraryService.Models.Models;

namespace LibraryService.BL.Interfaces.Repositories;

public interface IBookRepository
{
    Task<Book?> GetByIdAsync(string id);
    Task<List<Book>> GetAllAsync();
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);

    Task DeleteAsync(string id);
}
