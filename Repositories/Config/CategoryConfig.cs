using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			// burada primary keyimizide belirliyebiliriz ayrıca validation işlemlerinide burada gerçekleştirebiliriz.
			builder.HasData(
				new Category() { CategoryId = 1, CategoryName = "Kitaplar" },
				new Category() { CategoryId = 2, CategoryName = "Elektronik" }
				);

		}
	}
}
