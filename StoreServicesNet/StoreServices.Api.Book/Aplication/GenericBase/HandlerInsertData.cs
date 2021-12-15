namespace StoreServices.Api.Book.Aplication.GenericBase
{
    using MediatR;
    using StoreServices.Api.Book.Persistence;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class HandlerInsertData : IRequestHandler<ExecuteData>
    {
        protected readonly ContextBook _context;

        public HandlerInsertData(ContextBook context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public abstract Task<Unit> Handle(ExecuteData request, CancellationToken cancellationToken);
        
    }
}
