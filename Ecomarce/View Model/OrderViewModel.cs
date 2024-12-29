using Ecomarce.Models.Entites;

namespace Ecomarce.View_Model
{
    public class OrderViewModel
    {
        public int CustomerId { get; set; }
        public List<Customer>? customers { get; set; }
        public int ProductID { get; set; }  
        public int Quntity { get; set; }
        public List<Product>? Products { get; set; }
    }
}

