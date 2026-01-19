using LibraryService.Application.Interfaces.Repositories;
using LibraryService.Application.Services;
using LibraryService.Domain.Models;
using Moq;
using Xunit;

namespace LibraryService.Tests.Services;

public class BorrowingServiceTests
{
    private readonly Mock<IBookRepository> _bookRepositoryMock;
    private readonly Mock<IMemberRepository> _memberRepositoryMock;
    private readonly BorrowingService _service;

    public BorrowingServiceTests()
    {
        _bookRepositoryMock = new Mock<IBookRepository>();
        _memberRepositoryMock = new Mock<IMemberRepository>();

        _service = new BorrowingService(
            _bookRepositoryMock.Object,
            _memberRepositoryMock.Object);
    }

    [Fact]
    public async Task BorrowBookAsync_ShouldBorrowBook_WhenBookAndMemberExist()
    {
        var book = new Book { Id = "book1", IsBorrowed = false };
        var member = new Member { Id = "member1" };

        _bookRepositoryMock.Setup(r => r.GetByIdAsync("book1"))
            .ReturnsAsync(book);

        _memberRepositoryMock.Setup(r => r.GetByIdAsync("member1"))
            .ReturnsAsync(member);

        await _service.BorrowBookAsync("book1", "member1");

        Assert.True(book.IsBorrowed);
        _bookRepositoryMock.Verify(r => r.UpdateAsync(book), Times.Once);
    }

    [Fact]
    public async Task BorrowBookAsync_ShouldThrow_WhenBookAlreadyBorrowed()
    {
        var book = new Book { Id = "book1", IsBorrowed = true };
        var member = new Member { Id = "member1" };

        _bookRepositoryMock.Setup(r => r.GetByIdAsync("book1"))
            .ReturnsAsync(book);

        _memberRepositoryMock.Setup(r => r.GetByIdAsync("member1"))
            .ReturnsAsync(member);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.BorrowBookAsync("book1", "member1"));
    }
}
