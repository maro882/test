using Ecomarce.Models.Entites;

namespace Ecomarce.View_Model
{
    public class orderDetailsViewModel
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string name { get; set; }
        public List<OrderItems> OrderItems { get; set; }
    }
}
