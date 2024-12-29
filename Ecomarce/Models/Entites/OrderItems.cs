namespace Ecomarce.Models.Entites
{
    public class OrderItems
    {
        public int OrderItemsID { get; set; }
        public int OrderID {  get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Unitprice { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
