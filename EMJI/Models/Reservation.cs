namespace EMJI.Models
{
    public class Reservation
    {
        public DateTime Date { get; set; }
        public Client ClientInfo { get; set; }
        public int Size { get; set; }
        public string? Notes { get; set; }
    }
}
