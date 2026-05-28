using Ecommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public string PhoneCode { get; set; } = string.Empty;

        public ICollection<State> States { get; set; } = new List<State>();

    }
}
