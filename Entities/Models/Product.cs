using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Product
{

    public int ProductId { get; set; }

    [Required(ErrorMessage ="'ProductName' is required.")]
    [MinLength(3,ErrorMessage = "'ProductName' must be longer than 3 characters")]
    public string? ProductName { get; set; } = string.Empty;

    [Required(ErrorMessage = "'Price' is required.")]
    public decimal Price { get; set; }
}
