namespace StoreServices.Api.Book.Aplication.BookApplication.Queries.GetBooksAll
{
    using MediatR;
    using StoreServices.Api.Book.EntityDTO;
    using System.Collections.Generic;

    public class GetBookAllQuery : IRequest<List<MaterialLibraryDto>>
    {
    }
}