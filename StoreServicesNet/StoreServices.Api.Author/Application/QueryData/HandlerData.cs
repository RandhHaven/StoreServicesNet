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
        public readonly ContextAuthor context;

        public HandlerData(ContextAuthor _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
        }

        public async Task<List<BookAuthor>> Handle(ListAuthor request, CancellationToken cancellationToken)
        {
            var authors = await this.context.BookAuthor.ToListAsync();
            return authors;
        }
    }
}