using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class RepositoryManger : IRepositoryManager
	{
		private readonly RepositoryContext _context;
		private readonly IProductRepository _productRepository;

		public RepositoryManger(IProductRepository productRepository, RepositoryContext context)
		{
			_productRepository = productRepository;
			_context = context;
		}

		public IProductRepository Product => _productRepository;

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
