using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
	public interface IRepositoryManager 
	{
        IProductRepository Product  { get; }//sadece get olduğundan bu product repositorysine erişilebilir ancak değiştirilemez
		void Save();//veritabanındaki tüm değişiklikleri kaydetmek için kullanılır
    }
}
 