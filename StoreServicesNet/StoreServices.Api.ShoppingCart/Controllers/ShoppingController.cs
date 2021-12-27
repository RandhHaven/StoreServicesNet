namespace StoreServices.Api.ShoppingCart.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using StoreServices.Api.ShoppingCart.Aplication.InsertData;
    using StoreServices.Api.ShoppingCart.Aplication.QueryData;
    using StoreServices.Api.ShoppingCart.Controllers.Base;
    using StoreServices.Api.ShoppingCart.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static StoreServices.Api.ShoppingCart.Aplication.QueryData.QueryCartSession;

    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : WebApiController<ShoppingController>
    {
        #region Build
        public ShoppingController(IMediator _iMediator) : base(_iMediator)
        {
        }
        #endregion

        #region Actions
        [HttpPost]
        public async Task<ActionResult<Unit>> Insert(InsertCartSession.Execute data)
        {
            return await this._IMediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<CartSessionDetail>>> Get()
        {
            return await this._IMediator.Send(new CartSesionCollection());
        }
        #endregion
    }
}
