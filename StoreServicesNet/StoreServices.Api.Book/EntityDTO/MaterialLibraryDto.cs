namespace StoreServices.Api.Book.EntityDTO
{
    using System;

    public class MaterialLibraryDto
    {
        public Guid? MaterialLibraryID { get; set; }
        public String BookTittle { get; set; }
        public DateTime? DatePublish { get; set; }
        public Guid BookAuthor { get; set; }
    }
}