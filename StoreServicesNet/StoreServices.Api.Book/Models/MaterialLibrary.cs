namespace StoreServices.Api.Book.Models
{
    using System;

    public class MaterialLibrary
    {
        public Int64 MaterialLibraryID { get; set; }
        public String BookTittle { get; set; }
        public DateTime? DatePublish { get; set; }
        public Guid BookAuthor { get; set; }
    }
}
