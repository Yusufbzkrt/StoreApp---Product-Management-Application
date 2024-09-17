using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

		public void Create(T entity)
		{
			_context.Set<T>().Add(entity); //Product create işlemi veritaanına kayıt için
		}

		public IQueryable<T> FindAll(bool trackChanges)//trackChanges adındaki boolean parametre değişiklik izlemeyi (tracking) kontrol eder.
		{
			return trackChanges//trackChanges true ise ilk kısım değilse ilk kısım döner
				? _context.Set<T>()//veritabanından getirilen verilerin izlenmesini sağlar. Yani, yapılan değişiklikler otomatik olarak izlenir
				: _context.Set<T>().AsNoTracking();
		}

		public T? FindByConditation(Expression<Func<T, bool>> expression, bool trackChanges)
		{
			return trackChanges
				? _context.Set<T>().Where(expression).SingleOrDefault()
				: _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
		}//IrepositoryBase deki kuralı burda implemente ettik

		public void Remove(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}
	}
}
 