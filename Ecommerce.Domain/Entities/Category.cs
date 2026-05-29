using Ecommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Category : SoftDeletableEntity
    {

        public Guid? ParentCategoryId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsFeatured { get; set; } = false;   // shown on homepage

        public Guid CreatedBy { get; set; }             // FK -> User (default: super admin)

        // Navigation Properties
        public Category? ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ApplicationUser CreatedByUser { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
