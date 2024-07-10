using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>where T:class
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public  async Task Create(T model)
        {
           await  context.Set<T>().AddAsync(model);
        
        }

        public void Delete(int id)
        {
            var item = context.Set<T>().Find(id);
            if(item!=null)
             context.Set<T>().Remove(item);
   
        } 

        public async Task<IEnumerable<T>> getAll()
        {
           return  await context.Set<T>().ToListAsync();
           
        }

        public  async Task<T> GetById(int id)
        {

            return await context.Set<T>().FindAsync(id);
        }

        public void Update(T model)
        {
            context.Set<T>().Update(model);
        }
    }
}
