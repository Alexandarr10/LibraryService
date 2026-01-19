using FluentValidation;
using LibraryService.Application.Requests;

namespace LibraryService.Application.Validators;

public class AddBookRequestValidator : AbstractValidator<AddBookRequest>
{
    public AddBookRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(2);

        RuleFor(x => x.Author)
            .NotEmpty();
    }
}
