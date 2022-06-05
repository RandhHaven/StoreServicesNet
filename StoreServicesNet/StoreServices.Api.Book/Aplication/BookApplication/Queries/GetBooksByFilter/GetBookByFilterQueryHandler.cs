namespace StoreServices.Api.Book.Aplication.BookApplication.Queries.GetBooksByFilter
{
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using StoreServices.Api.Book.EntityDTO;
    using StoreServices.Api.Book.Models;
    using StoreServices.Api.Book.Persistence;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetBookByFilterQueryHandler : IRequestHandler<GetBookByFilterQuery, MaterialLibraryDto>
    {
        public readonly ContextBook context;
        private readonly IMapper mapper;

        public GetBookByFilterQueryHandler(ContextBook _context, IMapper _mapper)
        {
            context = context ?? throw new ArgumentNullException(nameof(context));
            mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MaterialLibraryDto> Handle(GetBookByFilterQuery request, CancellationToken cancellationToken)
        {
            var book = await this.context.MaterialLibrary
                    .AsNoTracking()
                    .Where(x => x.MaterialLibraryID == request.BookID)
                    .FirstOrDefaultAsync();
            if (Object.Equals(book, null))
            {
                throw new Exception("Book not found");
            }
            var bookDto = this.mapper.Map<MaterialLibrary, MaterialLibraryDto>(book);
            return bookDto;
        }
    }
}