using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepositories
{
    public interface IUnitOfWork<T>
    {
        //add all resopotires 
        public IProductsRepository productsRepository { get; set; }

        //commit and RollBack method 
        public Task<int> SaveChanges();

        
       

    }


}
