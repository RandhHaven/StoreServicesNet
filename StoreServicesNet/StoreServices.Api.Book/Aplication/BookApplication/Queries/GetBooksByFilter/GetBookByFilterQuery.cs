namespace StoreServices.Api.Book.Aplication.BookApplication.Queries.GetBooksByFilter
{
    using MediatR;
    using StoreServices.Api.Book.EntityDTO;
    using System;

    public class GetBookByFilterQuery : IRequest<MaterialLibraryDto>
    {
        public Guid? BookID { get; set; }
    }
}