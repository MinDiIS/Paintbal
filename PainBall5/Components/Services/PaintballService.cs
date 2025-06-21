using PainBall5.Components.Models;

namespace PainBall5.Components.Services;

public class PaintballService
{
    public IEnumerable<Game> GetAllGames() => _games;
    public IEnumerable<Booking> GetAllBookings() => _bookings;
    private List<Team> _teams = new();
    private List<Game> _games = new();
    private List<Booking> _bookings = new();
    private List<Payment> _payments = new();
    
    // Инициализация тестовых данных
    public PaintballService()
    {
        _games.AddRange(new[]
        {
            new Game { Id = 1, Date = DateTime.Today.AddDays(1).AddHours(10), AvailableSlots = 20, PricePerPlayer = 1000 },
            new Game { Id = 2, Date = DateTime.Today.AddDays(2).AddHours(12), AvailableSlots = 15, PricePerPlayer = 1000 },
            new Game { Id = 3, Date = DateTime.Today.AddDays(3).AddHours(14), AvailableSlots = 25, PricePerPlayer = 1200 }
        });
    }
    
    public IEnumerable<Game> GetAvailableGames() => _games.Where(g => g.AvailableSlots > 0);
    
    public void AddTeam(Team team)
    {
        team.Id = _teams.Any() ? _teams.Max(t => t.Id) + 1 : 1;
        _teams.Add(team);
    }
    
    public void CreateBooking(int teamId, int gameId)
    {
        var game = _games.First(g => g.Id == gameId);
        game.AvailableSlots--;
        
        _bookings.Add(new Booking
        {
            Id = _bookings.Any() ? _bookings.Max(b => b.Id) + 1 : 1,
            TeamId = teamId,
            GameId = gameId,
            BookingDate = DateTime.Now,
            IsPaid = false
        });
    }
    
    public void ProcessPayment(int bookingId, decimal amount)
    {
        _payments.Add(new Payment
        {
            Id = _payments.Any() ? _payments.Max(p => p.Id) + 1 : 1,
            BookingId = bookingId,
            Amount = amount,
            PaymentDate = DateTime.Now
        });
        
        var booking = _bookings.First(b => b.Id == bookingId);
        booking.IsPaid = true;
    }

    public void AddGame(Game game)
    {
        _games.Add(game);
    }

    public void DeleteGame(int id)
    {
        var game = _games.FirstOrDefault(g => g.Id == id);
        if (game != null)
        {
            _games.Remove(game);
        }
    }
    public Team GetTeam(int id) => _teams.FirstOrDefault(t => t.Id == id);
    public Game GetGame(int id) => _games.FirstOrDefault(g => g.Id == id);
}