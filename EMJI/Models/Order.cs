using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMJI.Models
{
    public class Order
    {
        public List<FoodItem> orders = new List<FoodItem>();
        public FoodStatus orderStatus
        {
            get
            {
                FoodStatus status = FoodStatus.Sent;
                foreach (FoodItem item in orders)
                {
                    if (item.Status == FoodStatus.Ordered)
                    {
                        status = FoodStatus.Ordered;
                        break;
                    }
                }
                return status;
            }
        }
    }
}
