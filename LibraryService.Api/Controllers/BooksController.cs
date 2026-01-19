using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Api.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    // POST api/books
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddBookRequest request)
    {
        await _bookService.AddAsync(request);
        return Ok();
    }

    // GET api/books
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }
}
