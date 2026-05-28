using Ecommerce.Domain.Entities.Common;
using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }

        public string? ExternalTransactionId { get; set; }  // ID from Stripe, PayPal, etc.
        public PaymentGateway Gateway { get; set; }
        public TransactionType TransactionType { get; set; }

        public decimal Amount { get; set; }
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;

        public string? GatewayResponse { get; set; }        // raw JSON from gateway
        public DateTime? PaymentDate { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public Order Order { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }

}
