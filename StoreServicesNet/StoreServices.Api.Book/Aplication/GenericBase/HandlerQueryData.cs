namespace StoreServices.Api.Book.Aplication.GenericBase
{
    using MediatR;
    using StoreServices.Api.Book.EntityDTO;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class HandlerQueryData : IRequestHandler<CollectionData, IEnumerable<GenericDTO>>
    {
        public abstract Task<IEnumerable<GenericDTO>> Handle(CollectionData request, CancellationToken cancellationToken);
    }
}
