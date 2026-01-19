using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.Application.Requests;
using LibraryService.Domain.Models;

namespace LibraryService.Application.Interfaces.Services;

public interface IBookService
{
    Task AddAsync(AddBookRequest request);
    Task<List<Book>> GetAllAsync();
}
