namespace StoreServices.Api.Book.Aplication.BookRequest
{
    using StoreServices.Api.Book.Aplication.GenericBase;
    using System;

    public class ExecuteBook : ExecuteData
    {
        public String BookTittle { get; set; }
        public DateTime? DatePublish { get; set; }
        public Guid BookAuthor { get; set; }
    }
}
