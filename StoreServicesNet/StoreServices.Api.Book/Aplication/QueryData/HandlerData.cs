namespace StoreServices.Api.Book.Aplication.QueryData
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using StoreServices.Api.Book.Models;
    using StoreServices.Api.Book.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class HandlerData : IRequestHandler<BookCollection, List<MaterialLibrary>>
    {
        public readonly ContextBook _context;

        public HandlerData(ContextBook context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<List<MaterialLibrary>> Handle(BookCollection request, CancellationToken cancellationToken)
        {
            var books = this._context.MaterialLibrary.ToListAsync();
            return books;
        }
    }
}