namespace StoreServices.RabbitMQ.Bus.BusRabbit
{
    using StoreServices.RabbitMQ.Bus.Commands;
    using StoreServices.RabbitMQ.Bus.Events;
    using System.Threading.Tasks;

    public interface IRabbitEventBus
    {
        Task SendCommand<T>(T command) where T : MessageCommand;
        void Publish<T>(T genericEvent) where T : EventQueue;

        void Subscribe<T, TH>(T genericEvent) where T : EventQueue where TH: IEventHandler<T>;

    }
}