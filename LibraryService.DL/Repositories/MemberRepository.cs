using LibraryService.BL.Interfaces.Repositories;
using LibraryService.Models.Models;
using LibraryService.DL.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LibraryService.DL.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly IMongoCollection<Member> _members;

    public MemberRepository(IOptionsMonitor<MongoSettings> options)
    {
        var settings = options.CurrentValue;
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.Database);

        _members = database.GetCollection<Member>("Members");
    }

    public async Task<Member?> GetByIdAsync(string id)
        => await _members.Find(m => m.Id == id).FirstOrDefaultAsync();
}
