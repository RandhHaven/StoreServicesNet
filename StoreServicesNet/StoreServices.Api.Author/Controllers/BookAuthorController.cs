namespace StoreServices.Api.Author.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using StoreServices.Api.Author.Application.InsertData;
    using StoreServices.Api.Author.Application.QueryData;
    using StoreServices.Api.Author.Controllers.Base;
    using StoreServices.Api.Author.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController : WebApiControllers<BookAuthorController>
    {
        #region Builds
        public BookAuthorController(IMediator _IMediator) : base(_IMediator)
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
        public async Task<ActionResult<List<BookAuthor>>> Get()
        {
            return await this._IMediator.Send(new ListAuthor());
        }
        #endregion
    }
}
