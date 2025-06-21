using System.ComponentModel.DataAnnotations;

namespace PainBall5.Components.Models;

public class Team
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Название команды обязательно")]
    [StringLength(50, ErrorMessage = "Название слишком длинное")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Имя капитана обязательно")]
    public string CaptainName { get; set; }
    [Required(ErrorMessage = "Телефон обязателен")]
    [Phone(ErrorMessage = "Неверный формат телефона")]
    public string Phone { get; set; }
    [Required(ErrorMessage = "Укажите количество игроков")]
    [Range(2, 20, ErrorMessage = "Команда должна быть от 2 до 20 игроков")]
    public int PlayersCount { get; set; }
}