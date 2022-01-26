namespace StoreServices.RabbitMQ.Bus.Commands
{
    using StoreServices.RabbitMQ.Bus.Events;
    using System;

    public abstract class MessageCommand : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected MessageCommand()
        {
            this.Timestamp = DateTime.UtcNow;
        }
    }
}
