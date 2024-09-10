using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T>
		where T : class, new ()
	{
		protected readonly RepositoryContext _context;

		protected RepositoryBase(RepositoryContext context)
		{
			_context = context;
		}

		public IQueryable<T> FindAll(bool trackChanges)//trackChanges adındaki boolean parametre değişiklik izlemeyi (tracking) kontrol eder.
		{
			return trackChanges//trackChanges true ise ilk kısım değilse ilk kısım döner
				? _context.Set<T>()//veritabanından getirilen verilerin izlenmesini sağlar. Yani, yapılan değişiklikler otomatik olarak izlenir
				: _context.Set<T>().AsNoTracking();
		}
	}
}
 