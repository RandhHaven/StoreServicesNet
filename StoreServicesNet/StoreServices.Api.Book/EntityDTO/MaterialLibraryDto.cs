﻿namespace StoreServices.Api.Book.EntityDTO
{
    using System;

    public class MaterialLibraryDto
    {
        public String BookTittle { get; set; }
        public DateTime? DatePublish { get; set; }
        public Guid BookAuthor { get; set; }
    }
}