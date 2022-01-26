namespace StoreServices.RabbitMQ.Bus.Events
{
    using MediatR;
    using System;

    public abstract class Message : IRequest<Boolean>
    {
        public String MessageType { get; protected set; }


        protected Message()
        {
            this.MessageType = GetType().Name;
        }
    }
}