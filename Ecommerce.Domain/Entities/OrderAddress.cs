using Ecommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class OrderAddress : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }

        public string RecipientName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Landmark { get; set; }

        // Snapshot of location names at order time
        public string CountryName { get; set; } = string.Empty;
        public string StateName { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;

        public string StreetAddress { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; }
        public string ZipCode { get; set; } = string.Empty;

        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public ApplicationUser User { get; set; } = null!;
        public Order Order { get; set; } = null!;
    }


}
