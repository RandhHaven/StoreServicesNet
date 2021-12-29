using System;

namespace StoreServices.Api.ShoppingCart.EntityDTO
{
    public class CarShoppingDetailDto
    {
        public Guid? BookID { get; set; }
        public String BookTittle { get; set; }
        public String AuthorTittle { get; set; }
        public DateTime? DatePublish { get; set; }
    }
}
