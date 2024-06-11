using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMJI.Models
{
    public class Table
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public Reservation Reservation { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int XSize { get; set; }
        public int YSize { get; set; }
        public int Rotation { get; set; }
        public int Id { get; set; }
        public TableStatus Status { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<Order> Order { get; set; }
        public List<FoodItem> FoodItems
        {
            get
            {
                List<FoodItem> result = new List<FoodItem>();
                if (Order != null)
                    foreach (Order order in Order)
                        foreach (FoodItem item in order.orders)
                            result.Add(item);
                return result;
            }
        }
        public bool Collapsed = false;
        public bool ShowTable { get
            {
                bool result = false;
                return result;
            } }

    }
    public enum TableStatus
    {
        Unassigned,
        Ready,
        Seated,
        Starters,
        Mains,
        Desserts,
        Dirty
    }
}
