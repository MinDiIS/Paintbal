namespace PainBall5.Components.Models;

public class Game
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int AvailableSlots { get; set; }
    public decimal PricePerPlayer { get; set; }
}