using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameters
{
	public class ProductRequestParameters : RequestParameters
	{
        public int? CategoryId { get; set; }
        public int MinPrice { get; set; } = 0;
		public int MaxPrice { get; set; } = int.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;//maxprice min den büyük değilse false döner
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public ProductRequestParameters() :this(1,6)
        {
            
        }

        public ProductRequestParameters(int pageNumber, int pageSize)
		{
			PageNumber = pageNumber;
			PageSize = pageSize;
		}
	}
}
