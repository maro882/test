namespace Ecomarce.Models.Entites
{
    public class Product
    {
       public int ProductID {  get; set; }  
       public string Name { get; set; }
       public decimal Price { get; set; }
       public string Description { get; set; }
       public int Quntity {  get; set; }
       public ICollection<OrderItems> OrderItems { get; set; }

    }
}
