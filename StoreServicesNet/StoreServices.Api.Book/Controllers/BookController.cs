namespace StoreServices.Api.Book.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using StoreServices.Api.Book.Aplication.BookApplication.Commands.CreateBook;
    using StoreServices.Api.Book.Aplication.BookApplication.Queries.GetBooksAll;
    using StoreServices.Api.Book.Controllers.Base;
    using StoreServices.Api.Book.EntityDTO;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static StoreServices.Api.Book.Aplication.QueryDataFilter.BookDataFilter;

    [Route("api/[controller]")]
    [ApiController]
    public sealed class BookController : WebApiControllers<BookController>
    {
        #region Build
        public BookController(IMediator _iMediator) : base(_iMediator)
        {
        }
        #endregion

        #region Actions
        [HttpPost]
        public async Task<ActionResult<Unit>> Insert(CreateBookCommand data)
        {
            return await this._IMediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<MaterialLibraryDto>>> Get()
        {
            return await this._IMediator.Send(new GetBookAllQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialLibraryDto>> GetFilter(Guid id)
        {
            return await this._IMediator.Send(new BookFilter { BookID = id });
        }
        #endregion
    }
}
