using Ecommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public Product Product { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }


}
