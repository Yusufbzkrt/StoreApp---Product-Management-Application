using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
	public class Order
	{
        public int OrderId { get; set; }

        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

        [Required(ErrorMessage ="Name is Required")]
        public String? Name { get; set; }
		public String? City { get; set; }

		[Required(ErrorMessage = "Adress is Required")]
		public String? Adress { get; set; }
        public bool GiftWrap { get; set; }//Hediye paketi
        public bool Shipped { get; set; }//sipariş kargoya verildimi
        public DateTime OrderedAt { get; set; } = DateTime.Now;
    }
}
