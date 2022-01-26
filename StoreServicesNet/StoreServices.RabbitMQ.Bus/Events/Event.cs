namespace StoreServices.RabbitMQ.Bus.Events
{
    using System;

    public class Event
    {
        public DateTime Timestamp { get; protected set; }

        protected Event()
        {
            this.Timestamp = DateTime.UtcNow;
        }
    }
}
