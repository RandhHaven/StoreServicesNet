namespace StoreServices.Api.Book.Controllers.Base
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public abstract class WebApiControllers<T> : ControllerBase
    {
        protected readonly IMediator _IMediator;

        #region Builds
        protected WebApiControllers(IMediator _iMediator)
        {
            this._IMediator = _iMediator ?? throw new ArgumentNullException(nameof(_iMediator));
        }
        #endregion

    }
}
