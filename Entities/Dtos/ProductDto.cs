using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
	public record ProductDto
	{
		public int ProductId { get; init; } //init ilgili nesne üzerinde değişiklik yapılmasına izin vermez.

		[Required(ErrorMessage = "'ProductName' is required.")]
		[MinLength(3, ErrorMessage = "'ProductName' must be longer than 3 characters")]
		[Display(Name = "Product Name")]
		public string? ProductName { get; init; } = string.Empty;

		[Required(ErrorMessage = "'Price' is required.")]
		public decimal Price { get; init; }
		public string? Summary { get; init; } = string.Empty;
		public string? ImageUrl { get; set; }

		[Display(Name = "Category Name")]
		public int? CategoryId { get; init; } 
	}
}
