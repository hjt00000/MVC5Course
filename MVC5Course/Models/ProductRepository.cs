using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => !p.IsDeleted);
        }
        public Product Find(int value)
        {
            return this.All().FirstOrDefault(p => p.ProductId == value);
        }
        public IQueryable<Product> All(bool isActive)
        {
            return this.All().Where(p => p.Active == isActive);
        }
    }

    public  interface IProductRepository : IRepository<Product>
	{

	}
}