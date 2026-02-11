using LibraryService.BL.Interfaces.Repositories;
using LibraryService.Models.Models;
using LibraryService.DL.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LibraryService.DL.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IMongoCollection<Book> _books;

    public BookRepository(IOptionsMonitor<MongoSettings> options)
    {
        var settings = options.CurrentValue;
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.Database);

        _books = database.GetCollection<Book>("Books");
    }

    public async Task<Book?> GetByIdAsync(string id)
        => await _books.Find(b => b.Id == id).FirstOrDefaultAsync();

    public async Task<List<Book>> GetAllAsync()
        => await _books.Find(_ => true).ToListAsync();

    public async Task AddAsync(Book book)
        => await _books.InsertOneAsync(book);

    public async Task UpdateAsync(Book book)
        => await _books.ReplaceOneAsync(b => b.Id == book.Id, book);

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}
