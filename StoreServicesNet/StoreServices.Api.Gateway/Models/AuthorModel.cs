namespace StoreServices.Api.Gateway.Models
{
    using System;

    public class AuthorModel
    {
        public Int64? BookAuthorID { get; set; }
        public String NameAuthor { get; set; }
        public String LastNameAuthor { get; set; }
        public DateTime? BirthDate { get; set; }
        public String BookAuthorGuid { get; set; }
    }
}