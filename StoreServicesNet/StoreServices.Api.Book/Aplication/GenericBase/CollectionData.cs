namespace StoreServices.Api.Book.Aplication.GenericBase
{
    using MediatR;
    using System.Collections.Generic;

    public class CollectionData<T, B> : IRequest<IEnumerable<B>>
    {
    }
}
