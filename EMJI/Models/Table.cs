using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMJI.Models
{
    public class Table
    {
        /// Lots of these should be set when food items are added, not when data is accessed.
        /// Have a variable for retrievable data that is only updated when bool is true/false and data does/doesnt require update based on context
        /// </summary>
        public string Name { get; set; }
        public string Notes { get; set; }
        public Reservation Reservation { get; set; }
        public double XPos { get; set; }
        public double YPos { get; set; }
        public int XSize { get; set; }
        public int YSize { get; set; }
        public int Rotation { get; set; }
        public int Id { get; set; }
        public int Seats = 2;
        public TableStatus Status { get; set; }
        public DateTime LastUpdated { get; set; }
        public required List<Order> Order { get; set; }
        public string Position { get => string.Format("top: {0}px; left: {1}px;", YPos, XPos); }
        public bool OrderFulFilled
        {
            get
            {
                bool result = true;
                foreach (FoodItem item in FoodItems)
                    if (item.Status != FoodStatus.Sent)
                    {
                        result = false;
                        break;
                    }
                return result;
            }
        }
        public string OrderFulFilledText { get => (OrderFulFilled) ? "Complete" : "Incomplete"; }
        public string OrderFulfilledColorText
        {
            get => OrderFulfilledColor.ToHex();
        }
        public Color OrderFulfilledColor
        {
            get => (OrderFulFilled) ? new Color(0, 255, 0) : new Color(255, 0, 0);
        }

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
        public bool ShowTable
        {
            get
            {
                bool result = false;
                return result;
            }
        }
        public TableStatus NextStatus
        {
            get
            {
                int i = (int)Status + 1;
                if (i > Enum.GetNames(typeof(TableStatus)).Length)
                    i = 0;
                return (TableStatus)i;
            }
        }

    }
    
    public enum TableStatus
    {
        Unassigned = 0,
        Assigned = 1,
        Ready = 2,
        Seated = 3,
        Starters = 4,
        Mains = 5,
        Desserts = 6,
        Dirty = 7
    }
}
