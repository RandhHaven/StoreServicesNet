namespace StoreServices.Api.Book.Aplication.InsertData
{
    using AutoMapper;
    using MediatR;
    using StoreServices.Api.Book.Models;
    using StoreServices.Api.Book.Persistence;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class HandlerData : IRequestHandler<ExecuteData>
    {
        public readonly ContextBook _context;
       
        public HandlerData(ContextBook context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(ExecuteData request, CancellationToken cancellationToken)
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
    }
}
