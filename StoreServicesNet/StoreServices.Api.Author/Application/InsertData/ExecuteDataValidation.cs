namespace StoreServices.Api.Author.Application.InsertData
{
    using FluentValidation;

    public class ExecuteDataValidation : AbstractValidator<ExecuteData>
    {
        public ExecuteDataValidation()
        {
            RuleFor(x => x.NameAuthor).NotEmpty();
            RuleFor(x => x.LastNameAuthor).NotEmpty();
            RuleFor(x => x.BirthDate).NotNull();
        }
    }
}
