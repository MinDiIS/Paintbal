// Models/PaymentModel.cs
using System.ComponentModel.DataAnnotations;

public class PaymentModel
{
    [Required(ErrorMessage = "Номер карты обязателен")]
    [CreditCard(ErrorMessage = "Неверный номер карты")]
    [Display(Name = "Номер карты")]
    public string CardNumber { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Срок действия обязателен")]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$", 
        ErrorMessage = "Неверный формат (MM/YY или MM/YYYY)")]
    [Display(Name = "Срок действия")]
    public string ExpiryDate { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "CVV/CVC обязателен")]
    [RegularExpression(@"^[0-9]{3,4}$", 
        ErrorMessage = "Должно быть 3 или 4 цифры")]
    [Display(Name = "CVV/CVC")]
    public string Cvv { get; set; } = string.Empty;
}