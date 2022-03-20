namespace StoreServices.RabbitMQ.Bus.Events
{
    internal class EmailEventQueue : EventQueue
    {
        public string Addressee { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }

        public EmailEventQueue(string addressee, string tittle, string content)
        {
            this.Addressee = addressee;
            this.Tittle = tittle;
            this.Content = content;
        }
    }
}
