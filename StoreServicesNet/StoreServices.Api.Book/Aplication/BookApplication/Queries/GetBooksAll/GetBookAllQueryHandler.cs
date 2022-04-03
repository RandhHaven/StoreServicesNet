namespace StoreServices.Api.Book.Aplication.BookApplication.Queries.GetBooksAll
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

    public class GetBookAllQueryHandler : IRequestHandler<GetBookAllQuery, List<MaterialLibraryDto>>
    {
        public readonly ContextBook context;
        private readonly IMapper mapper;

        public GetBookAllQueryHandler(ContextBook _context, IMapper _mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<MaterialLibraryDto>> Handle(GetBookAllQuery request, CancellationToken cancellationToken)
        {
            var books = await this.context.MaterialLibrary.AsNoTracking().ToListAsync();
            var booksDto = this.mapper.Map<List<MaterialLibrary>, List<MaterialLibraryDto>>(books);
            return booksDto;
        }
    }
}