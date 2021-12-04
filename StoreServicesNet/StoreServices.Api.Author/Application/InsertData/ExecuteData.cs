namespace StoreServices.Api.Author.Application.InsertData
{
    using MediatR;
    using System;

    public class ExecuteData : IRequest
    {
        public String NameAuthor { get; set; }
        public String LastNameAuthor { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}