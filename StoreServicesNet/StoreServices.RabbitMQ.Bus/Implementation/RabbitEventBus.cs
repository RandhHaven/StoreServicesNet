namespace StoreServices.RabbitMQ.Bus.Implementation
{
    using global::RabbitMQ.Client;
    using MediatR;
    using Newtonsoft.Json;
    using StoreServices.RabbitMQ.Bus.BusRabbit;
    using StoreServices.RabbitMQ.Bus.Commands;
    using StoreServices.RabbitMQ.Bus.Events;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class RabbitEventBus : IRabbitEventBus
    {
        private readonly IMediator mediator;
        private readonly Dictionary<String, List<Type>> handler;
        private readonly List<Type> typeEvent;

        public RabbitEventBus(IMediator _mediator)
        {
            this.mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
            this.handler = new Dictionary<string, List<Type>>();
            this.typeEvent = new List<Type>();
        }

        public void Publish<T>(T genericEvent) where T : Event
        {
            var factory = new ConnectionFactory { HostName = "localhost " };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var eventName = genericEvent.GetType().Name;
                channel.QueueDeclare(eventName, false, false, false, null);

                var message = JsonConvert.SerializeObject(genericEvent);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(String.Empty, eventName, null, body);
            }
            throw new NotImplementedException();
        }

        public Task SendCommand<T>(T command) where T : MessageCommand
        {
            return this.mediator.Send(command);
        }

        public void Subscribe<T, TH>(T genericEvent)
            where T : Event
            where TH : IEventHandler<T>
        {
            throw new NotImplementedException();
        }
    }
}
