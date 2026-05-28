using Ecommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        /// <summary>Rating value between 1 and 5.</summary>
        public int Rating { get; set; }

        public string? Comment { get; set; }
        public bool IsApproved { get; set; } = false;

        // Navigation Properties
        public ApplicationUser User { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }


}
