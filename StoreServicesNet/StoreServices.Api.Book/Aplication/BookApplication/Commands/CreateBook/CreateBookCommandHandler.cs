namespace StoreServices.Api.Book.Aplication.BookApplication.Commands.CreateBook
{
    using MediatR;
    using StoreServices.Api.Book.Models;
    using StoreServices.Api.Book.Persistence;
    using StoreServices.RabbitMQ.Bus.BusRabbit;
    using StoreServices.RabbitMQ.Bus.Events;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Unit>
    {
        public readonly ContextBook context;
        private readonly IRabbitEventBus eventBus;

        public CreateBookCommandHandler(ContextBook _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
        }

        public CreateBookCommandHandler(ContextBook _context, IRabbitEventBus _eventBus)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
            eventBus = _eventBus ?? throw new ArgumentNullException(nameof(_eventBus));
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new MaterialLibrary
            {
                BookTittle = request.BookTittle,
                DatePublish = request.DatePublish,
                BookAuthor = request.BookAuthor
            };

            this.context.MaterialLibrary.Add(book);
            var value = await this.context.SaveChangesAsync();
            this.eventBus.Publish(new EmailEventQueue("randhall.rd@gmail.com", request.BookTittle, "Este contenido es un ejemplo"));
            return Unit.Value;
        }
    }
}
