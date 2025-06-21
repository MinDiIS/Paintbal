﻿namespace PainBall5.Components.Models;

public class Payment
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
}