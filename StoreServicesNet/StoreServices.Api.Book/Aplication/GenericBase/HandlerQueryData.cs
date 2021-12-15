namespace StoreServices.Api.Book.Aplication.GenericBase
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class HandlerQueryData<T, A, B> : IRequestHandler<CollectionData<T,A>, IEnumerable<A>>
    {
        public abstract Task<IEnumerable<A>> Handle(CollectionData<T, A> request, CancellationToken cancellationToken);
    }
}
