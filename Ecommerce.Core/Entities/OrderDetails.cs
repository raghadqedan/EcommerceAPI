﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public  class OrderDetails
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Orders? Order { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Products? Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
