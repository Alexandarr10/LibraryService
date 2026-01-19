using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.BL.Requests;
using LibraryService.Models.Models;

namespace LibraryService.BL.Interfaces.Services;

public interface IBookService
{
    Task AddAsync(AddBookRequest request);
    Task<List<Book>> GetAllAsync();
}
