using Ecommerce.Domain.Entities.Common;
using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Order : SoftDeletableEntity
    {
        public Guid UserId { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal ShippingFees { get; set; }       // dynamic later

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;
        public PaymentMethod PaymentMethod { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public ApplicationUser User { get; set; } = null!;
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public OrderAddress? ShippingAddress { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }


}
