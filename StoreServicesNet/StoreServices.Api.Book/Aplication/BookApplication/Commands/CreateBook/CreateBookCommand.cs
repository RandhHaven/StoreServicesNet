using MediatR;
using System;

namespace StoreServices.Api.Book.Aplication.BookApplication.Commands.CreateBook
{
    public class CreateBookCommand : IRequest
    {
        public String BookTittle { get; set; }
        public DateTime? DatePublish { get; set; }
        public Guid BookAuthor { get; set; }
    }
}
