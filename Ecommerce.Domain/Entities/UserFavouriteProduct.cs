using Ecommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class UserFavouriteProduct : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }

        // Navigation Properties
        public Product Product { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }

}
