using System;
using System.Collections.Generic;

namespace StoreServices.Api.ShoppingCart.EntityDTO
{
    public class CarShoppingDto
    {
        public Int64 CarShoppingID { get; set; }
        public DateTime? CreateDateSession { get; set; }
        public List<CarShoppingDetailDto> ProductList { get; set; }
    }
}
