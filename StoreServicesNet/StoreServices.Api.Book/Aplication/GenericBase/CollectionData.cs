namespace StoreServices.Api.Book.Aplication.GenericBase
{
    using MediatR;
    using StoreServices.Api.Book.EntityDTO;
    using System.Collections.Generic;

    public class CollectionData : IRequest<IEnumerable<GenericDTO>>
    {
    }
}
