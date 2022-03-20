using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace StoreServices.RabbitMQ.Bus.Implementation
{
    using MediatR;
    using Newtonsoft.Json;
    using StoreServices.RabbitMQ.Bus.BusRabbit;
    using StoreServices.RabbitMQ.Bus.Commands;
    using StoreServices.RabbitMQ.Bus.Events;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        public void Publish<T>(T genericEvent) where T : EventQueue
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
        }

        public Task SendCommand<T>(T command) where T : MessageCommand
        {
            return this.mediator.Send(command);
        }

        public void Subscribe<T, TH>(T genericEvent)
            where T : EventQueue
            where TH : IEventHandler<T>
        {
            var eventoNombre = typeof(T).Name;
            var manejadorEventoTipo = typeof(TH);

            if (!typeEvent.Contains(typeof(T)))
            {
                typeEvent.Add(typeof(T));
            }

            if (!handler.ContainsKey(eventoNombre))
            {
                handler.Add(eventoNombre, new List<Type>());
            }

            if (handler[eventoNombre].Any(x => x.GetType() == manejadorEventoTipo))
            {
                throw new ArgumentException($"El manejador {manejadorEventoTipo.Name} fue registrado anteriormente por {eventoNombre}");
            }

            handler[eventoNombre].Add(manejadorEventoTipo);

            var factory = new ConnectionFactory()
            {
                HostName = "rabbit-vaxi-web",
                DispatchConsumersAsync = true
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();


            channel.QueueDeclare(eventoNombre, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Delegate;

            channel.BasicConsume(eventoNombre, true, consumer);
        }

        private async Task Consumer_Delegate(object sender, BasicDeliverEventArgs e)
        {
            var nombreEvento = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                if (handler.ContainsKey(nombreEvento))
                {

                    var subscriptions = handler[nombreEvento];
                    foreach (var sb in subscriptions)
                    {
                        var manejador = Activator.CreateInstance(sb);
                        if (manejador == null) continue;

                        var tipoEvento = typeEvent.SingleOrDefault(x => x.Name == nombreEvento);
                        var eventoDS = JsonConvert.DeserializeObject(message, tipoEvento);

                        var concretoTipo = typeof(IEventHandler<>).MakeGenericType(tipoEvento);

                        await (Task)concretoTipo.GetMethod("Handle").Invoke(manejador, new object[] { eventoDS });

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}