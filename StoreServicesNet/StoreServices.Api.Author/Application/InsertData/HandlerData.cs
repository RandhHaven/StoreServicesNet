namespace StoreServices.Api.Author.Application.InsertData
{
    using MediatR;
    using StoreServices.Api.Author.Models;
    using StoreServices.Api.Author.Persistence;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class HandlerData : IRequestHandler<ExecuteData>
    {
        public readonly ContextAuthor _context;

        public HandlerData(ContextAuthor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(ExecuteData request, CancellationToken cancellationToken)
        {
            var author = new BookAuthor
            {
                NameAuthor = request.NameAuthor,
                LastNameAuthor = request.LastNameAuthor,
                BirthDate = request.BirthDate,
                BookAuthorGuid = Convert.ToString(Guid.NewGuid())
            };

            this._context.BookAuthor.Add(author);
            var value = await this._context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}