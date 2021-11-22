using System;

namespace StoreServices.Api.Author.Models
{
    public class AcademicDegree
    {
        public Int64 AcademicDegreeID { get; set; }
        public String NameGraduate { get; set; }
        public String AcademicCenter{get; set;}
        public DateTime? DateDegree { get; set; }
        public Int64? BookAuthorID { get; set; }
        public BookAuthor BookAuthor { get; set; }
        public String AcademicDegreeGuid { get; set; }
    }
}
