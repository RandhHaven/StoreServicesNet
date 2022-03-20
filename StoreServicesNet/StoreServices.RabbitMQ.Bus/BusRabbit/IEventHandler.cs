namespace StoreServices.RabbitMQ.Bus.BusRabbit
{
    using StoreServices.RabbitMQ.Bus.Events;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : EventQueue
    {
        Task Handle(TEvent @TEvent);
    }

    public interface IEventHandler
    {
    }
}