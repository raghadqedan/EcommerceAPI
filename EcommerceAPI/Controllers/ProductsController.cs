using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Ecommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcductsController : ControllerBase
    {
        private readonly IUnitOfWork<Products> unitOfWork;

        public ProcductsController(IUnitOfWork<Products> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetAll()
        {
            var products = await unitOfWork.productsRepository.getAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var product = await unitOfWork.productsRepository.GetById(id);
            return Ok(product);

        }
        [HttpPost]
        public async void create(Products model)
            
        {
            await unitOfWork.productsRepository.Create(model);
           await  unitOfWork.SaveChanges();

        }
        [HttpPut]
        public async Task Update(Products model) {
            unitOfWork.productsRepository.Update(model);
           await  unitOfWork.SaveChanges();
        }

        [HttpDelete]
        public async Task Delete(int id )
        {
            unitOfWork.productsRepository.Delete(id);
            await unitOfWork.SaveChanges();
        }

    }
}
