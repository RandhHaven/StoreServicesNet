namespace StoreServices.Api.Author.Application.QueryData
{
    using MediatR;
    using StoreServices.Api.Author.Models;
    using System.Collections.Generic;

    public class ListAuthor : IRequest<List<BookAuthor>>
    {
    }
}
