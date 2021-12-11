namespace StoreServices.Api.Book.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using StoreServices.Api.Book.Aplication.InsertData;
    using StoreServices.Api.Book.Aplication.QueryData;
    using StoreServices.Api.Book.Controllers.Base;
    using StoreServices.Api.Book.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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
        public async Task<ActionResult<List<MaterialLibrary>>> Get()
        {
            return await this._IMediator.Send(new BookCollection());
        }
        #endregion
    }
}
