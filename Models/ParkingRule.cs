namespace CarPark.API.Models
{
    public class ParkingRule
    {
        public int Id { get; set; }
        public int EntranceFee { get; set; }
        public int FirstHourCost { get; set; }
        public int SuccessiveHourCost { get; set; }
    }
}
