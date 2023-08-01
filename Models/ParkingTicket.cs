namespace CarPark.API.Models
{
    public class ParkingTicket
    {
        public int Id { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int TotalCost { get; set; }
    }
}
