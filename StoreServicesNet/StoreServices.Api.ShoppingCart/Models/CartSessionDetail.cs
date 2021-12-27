namespace StoreServices.Api.ShoppingCart.Models
{
    using System;

    public class CartSessionDetail
    {
        public Int64? CartSessionDetailID { get; set; }
        public DateTime? CreateDate { get; set; }
        public String ProductSelected { get; set; }
        public Int64 CartSessionID { get; set; }
        public CartSession CartSession { get; set; }
    }
}
