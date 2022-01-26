namespace StoreServices.Api.Gateway.Interfaces
{
    using StoreServices.Api.Gateway.Models;
    using System;
    using System.Threading.Tasks;

    public interface IAuthor
    {
        Task<(Boolean result, AuthorModel author, string errorMessage)> GetAuthor(Guid authorId);
    }
}
