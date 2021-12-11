namespace StoreServices.Api.Book.Aplication.InsertData
{
    using MediatR;
    using System;

    public class ExecuteData : IRequest
    {
        public String BookTittle { get; set; }
        public DateTime? DatePublish { get; set; }
        public Guid BookAuthor { get; set; }
    }
}
