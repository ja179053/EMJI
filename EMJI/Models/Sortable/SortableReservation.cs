
namespace EMJI.Models.Sortable
{
    public class SortableReservation : IEquatable<SortableReservation>, IComparable<SortableReservation>
    {
        static int nextID = 0;
        static int NextID
        {
            get
            {
                nextID++;
                return nextID - 1;
            }
        }
        public int ID = NextID;
        public SortableReservation(Reservation r)
        {
            reservation = r;
        }
        public Reservation reservation;
        public int CompareTo(SortableReservation comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;

            else
                return this.reservation.Date.CompareTo(comparePart.reservation.Date);
        }
        public bool Equals(SortableReservation other)
        {
            if (other == null) return false;
            return (this.reservation.Date.Equals(other.reservation.Date));
        }
    }
}
