using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMJI.Models
{
    public class FoodItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public FoodStatus Status { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderedTime { get; set; }
    }
    public enum FoodStatus
    {
        Ordered,
        Cooking,
        Sent
    }
}
