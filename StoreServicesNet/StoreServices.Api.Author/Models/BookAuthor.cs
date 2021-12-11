namespace StoreServices.Api.Author.Models
{
    using System;
    using System.Collections.Generic;

    public class BookAuthor
    {
        public Int64? BookAuthorID { get; set; }
        public String NameAuthor { get; set; }
        public String LastNameAuthor { get; set; }
        public DateTime? BirthDate { get; set; }
        public ICollection<AcademicDegree> AcademicDegreeList { get; set; }
        public String BookAuthorGuid { get; set; }
    }
}
