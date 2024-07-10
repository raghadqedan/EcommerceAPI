using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Image { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Categories? Category { get; set; }

        public ICollection<OrderDetails> OrdersDetails { get; set; } = new HashSet<OrderDetails>();


    }
}
