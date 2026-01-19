using LibraryService.Models.Models;

namespace LibraryService.BL.Interfaces.Repositories;

public interface IMemberRepository
{
    Task<Member?> GetByIdAsync(string id);
}
