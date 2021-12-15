namespace StoreServices.Api.Book.Aplication.BookRequest
{
    using MediatR;
    using StoreServices.Api.Book.Aplication.GenericBase;
    using StoreServices.Api.Book.Models;
    using StoreServices.Api.Book.Persistence;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class HandlerInsertBook : HandlerInsertData
    {
        public HandlerInsertBook(ContextBook context) : base(context)
        {
        }

        public async Task<Unit> Handle(ExecuteBook request, CancellationToken cancellationToken)
        {
            var book = new MaterialLibrary
            {
                BookTittle = request.BookTittle,
                DatePublish = request.DatePublish,
                BookAuthor = Guid.NewGuid()
            };

            this._context.MaterialLibrary.Add(book);
            var value = await this._context.SaveChangesAsync();

            return Unit.Value;
        }

        public override Task<Unit> Handle(ExecuteData request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
