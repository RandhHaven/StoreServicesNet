namespace StoreServices.Api.ShoppingCart.Controllers.Base
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public abstract class WebApiController<T> : ControllerBase
    {
        protected readonly IMediator _IMediator;

        #region Builds
        protected WebApiController(IMediator _iMediator)
        {
            this._IMediator = _iMediator ?? throw new ArgumentNullException(nameof(_iMediator));
        }
        #endregion

    }
}