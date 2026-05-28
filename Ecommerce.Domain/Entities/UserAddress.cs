using Ecommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class UserAddress : BaseEntity
    {
        public Guid UserId { get; set; }

        public string RecipientName { get; set; } = string.Empty;   // max 100
        public string PhoneNumber { get; set; } = string.Empty;     // max 20

        public string? Landmark { get; set; }                        // max 255

        public Guid CountryId { get; set; }
        public Guid StateId { get; set; }
        public Guid CityId { get; set; }

        public string AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; }

        public string ZipCode { get; set; } = string.Empty;         // max 20

        public bool IsDefault { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation Properties
        public ApplicationUser User { get; set; } = null!;
        public Country Country { get; set; } = null!;
        public State State { get; set; } = null!;
        public City City { get; set; } = null!;
    }

}
