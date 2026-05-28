using Ecommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class State : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid CountryId { get; set; }

        // Navigation Properties
        public Country Country { get; set; } = null!;
        public ICollection<City> Cities { get; set; } = new List<City>();
        public ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
    }

}
