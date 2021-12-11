namespace StoreServices.Api.Book.Aplication.InsertData
{
    using FluentValidation;

    public class ExecuteDataValidation : AbstractValidator<ExecuteData>
    {
        public ExecuteDataValidation()
        {
            RuleFor(x => x.BookTittle).NotEmpty();
            RuleFor(x => x.DatePublish).NotEmpty();
            RuleFor(x => x.DatePublish).NotNull();
            RuleFor(x => x.BookAuthor).NotEmpty();
        }
    }
}
