using LibraryService.BL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Host.Controllers;

[ApiController]
[Route("api/borrow")]
public class BorrowingController : ControllerBase
{
    private readonly IBorrowingService _borrowingService;

    public BorrowingController(IBorrowingService borrowingService)
    {
        _borrowingService = borrowingService;
    }

    // POST api/borrow/{bookId}/member/{memberId}
    [HttpPost("{bookId}/member/{memberId}")]
    public async Task<IActionResult> Borrow(string bookId, string memberId)
    {
        await _borrowingService.BorrowBookAsync(bookId, memberId);
        return Ok();
    }
}
