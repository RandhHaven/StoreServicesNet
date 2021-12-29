namespace StoreServices.Api.ShoppingCart.Services.BookService
{
    using StoreServices.Api.ShoppingCart.Services.RemoteModels;
    using System;
    using System.Threading.Tasks;

    public interface IBookService
    {
        Task<(Boolean result, RemoteBook book, String ErrorMessage)> GetBook(Guid ID);
    }
}
