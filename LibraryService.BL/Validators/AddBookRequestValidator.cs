using FluentValidation;
using LibraryService.BL.Requests;

namespace LibraryService.BL.Validators;

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
