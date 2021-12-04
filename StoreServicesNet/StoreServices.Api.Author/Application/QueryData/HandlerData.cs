namespace StoreServices.Api.Author.Application.QueryData
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using StoreServices.Api.Author.Models;
    using StoreServices.Api.Author.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class HandlerData : IRequestHandler<ListAuthor, List<BookAuthor>>
    {
        public readonly ContextAuthor _context;

        public HandlerData(ContextAuthor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<BookAuthor>> Handle(ListAuthor request, CancellationToken cancellationToken)
        {
            var authors = await this._context.BookAuthor.ToListAsync();
            return authors;
        }
    }
}
