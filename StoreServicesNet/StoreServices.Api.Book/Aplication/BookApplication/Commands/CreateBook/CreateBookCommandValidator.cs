namespace StoreServices.Api.Book.Aplication.BookApplication.Commands.CreateBook
{
    using FluentValidation;

    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.BookTittle).NotEmpty();
            RuleFor(x => x.DatePublish).NotEmpty();
            RuleFor(x => x.DatePublish).NotNull();
            RuleFor(x => x.BookAuthor).NotEmpty();
        }
    }
}