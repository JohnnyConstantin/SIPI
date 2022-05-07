using System.ComponentModel.DataAnnotations;

namespace NotificationSystemWeb.Models;

public class User
{
    /// <summary>
    /// Class keeps main info about each user
    /// </summary>
    public int Id { get; set; }
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }

    public string? Email { get; set; }
    public List<Stack>? Stacks { get; set; } = new();
}