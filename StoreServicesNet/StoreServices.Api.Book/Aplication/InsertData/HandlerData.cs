namespace StoreServices.Api.Book.Aplication.InsertData
{
    using MediatR;
    using StoreServices.Api.Book.Persistence;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class HandlerData : IRequestHandler<ExecuteData>
    {
        public readonly ContextBook _context;

        public HandlerData(ContextBook context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Unit> Handle(ExecuteData request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
