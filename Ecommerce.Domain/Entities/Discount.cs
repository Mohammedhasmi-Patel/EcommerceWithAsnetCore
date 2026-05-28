using Ecommerce.Domain.Entities.Common;
using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public string Name { get; set; } = string.Empty;       
        public string? CouponCode { get; set; }                 

        public DiscountType DiscountType { get; set; }
        public decimal DiscountValue { get; set; }

        public DateTime StartsAt { get; set; }
        public DateTime ExpiresAt { get; set; }

        public bool IsActive { get; set; } = true;
    }

}
