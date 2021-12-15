namespace StoreServices.Api.Book.Aplication.QueryData
{
    using MediatR;
    using StoreServices.Api.Book.EntityDTO;
    using System.Collections.Generic;

    public class BookCollection : IRequest<List<MaterialLibraryDto>>
    {
    }
}
