namespace StoreServices.RabbitMQ.Bus.Events
{
    using System;

    public class EventQueue
    {
        public DateTime Timestamp { get; protected set; }

        protected EventQueue()
        {
            this.Timestamp = DateTime.UtcNow;
        }
    }
}
