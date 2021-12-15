namespace StoreServices.Api.Book.Aplication.QueryData
{
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using StoreServices.Api.Book.EntityDTO;
    using StoreServices.Api.Book.Models;
    using StoreServices.Api.Book.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class HandlerData : IRequestHandler<BookCollection, List<MaterialLibraryDto>>
    {
        public readonly ContextBook _context;
        private readonly IMapper _mapper;
        public HandlerData(ContextBook context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<MaterialLibraryDto>> Handle(BookCollection request, CancellationToken cancellationToken)
        {
            var books = await this._context.MaterialLibrary.ToListAsync();
            var booksDto = _mapper.Map<List<MaterialLibrary>, List<MaterialLibraryDto>>(books);
            return booksDto;
        }
    }
}