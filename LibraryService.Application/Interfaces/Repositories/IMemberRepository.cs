using LibraryService.Domain.Models;

namespace LibraryService.Application.Interfaces.Repositories;

public interface IMemberRepository
{
    Task<Member?> GetByIdAsync(string id);
}
