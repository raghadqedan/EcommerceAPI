using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Ecommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductsRepository : GenericRepository<Products>,IProductsRepository
    {
        
        public ProductsRepository(ApplicationDbContext context):base(context)
        {
        }
    }
}
