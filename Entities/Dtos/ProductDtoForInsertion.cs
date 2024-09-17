using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
	public record ProductDtoForInsertion
	{
		public string ProductName { get; set; }
		public decimal Price { get; set; }
		public int? CategoryId { get; set; }
	}
}
