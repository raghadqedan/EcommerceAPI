using Ecommerce.Core.IRepositories;
using Ecommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context){
            this.context = context;
            this.productsRepository = new ProductsRepository(context);
        }
        public IProductsRepository productsRepository { get; set ; }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

    }
}
