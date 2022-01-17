namespace StoreServices.Api.Book.Aplication.QueryDataFilter
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

    public class BookDataFilter
    {
        public class BookFilter : IRequest<MaterialLibraryDto>
        {
            public Guid? BookID { get; set; }
        }

        public class BookHandler : IRequestHandler<BookFilter, MaterialLibraryDto>
        {
            public readonly ContextBook _context;
            private readonly IMapper _mapper;

            public BookHandler(ContextBook context, IMapper mapper)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<MaterialLibraryDto> Handle(BookFilter request, CancellationToken cancellationToken)
            {
                var book = await this._context.MaterialLibrary.Where(x => x.MaterialLibraryID == request.BookID).FirstOrDefaultAsync();
                if (Object.Equals(book, null))
                {
                    throw new Exception("Book not found");
                }
                var bookDto = _mapper.Map<MaterialLibrary, MaterialLibraryDto>(book);
                return bookDto;
            }
        }
    }
}
