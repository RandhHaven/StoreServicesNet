namespace StoreServices.Api.Book.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using StoreServices.Api.Book.Aplication.InsertData;
    using StoreServices.Api.Book.Aplication.QueryData;
    using StoreServices.Api.Book.Controllers.Base;
    using StoreServices.Api.Book.EntityDTO;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static StoreServices.Api.Book.Aplication.QueryDataFilter.BookDataFilter;

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : WebApiControllers<BookController>
    {
        #region Build
        public BookController(IMediator _iMediator) : base(_iMediator)
        {
        }
        #endregion

        #region Actions
        [HttpPost]
        public async Task<ActionResult<Unit>> Insert(ExecuteData data)
        {
            return await this._IMediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<MaterialLibraryDto>>> Get()
        {
            return await this._IMediator.Send(new BookCollection());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialLibraryDto>> GetFilter(Guid id)
        {
            return await this._IMediator.Send(new BookFilter { BookID = id });
        }
        #endregion
    }
}
