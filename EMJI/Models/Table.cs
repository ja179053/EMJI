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
