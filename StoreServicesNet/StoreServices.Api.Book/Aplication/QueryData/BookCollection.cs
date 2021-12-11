namespace StoreServices.Api.Book.Aplication.QueryData
{
    using MediatR;
    using StoreServices.Api.Book.Models;
    using System.Collections.Generic;

    public class BookCollection : IRequest<List<MaterialLibrary>>
    {
    }
}
