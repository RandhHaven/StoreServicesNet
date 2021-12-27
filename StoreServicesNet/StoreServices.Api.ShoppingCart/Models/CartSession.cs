namespace StoreServices.Api.ShoppingCart.Models
{
    using System;
    using System.Collections.Generic;

    public class CartSession
    {
        public Int64? CartSessionID { get; set; }
        public DateTime? CreateDate { get; set; }
        public ICollection<CartSessionDetail> ListDetail { get; set; }
    }
}
