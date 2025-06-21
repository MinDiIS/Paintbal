namespace PainBall5.Components.Models;

public class Booking
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public int GameId { get; set; }
    public DateTime BookingDate { get; set; }
    public bool IsPaid { get; set; }
}