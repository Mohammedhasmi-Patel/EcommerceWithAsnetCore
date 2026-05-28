using Ecommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid StateId { get; set; }

        // Navigation Properties
        public State State { get; set; } = null!;
        public ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
    }

}
