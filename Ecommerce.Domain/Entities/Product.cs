using Ecommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Product : SoftDeletableEntity
    {
        public Guid CategoryId { get; set; }

        public string Slug { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }


        public decimal Price { get; set; }
        public decimal? StrikethroughPrice { get; set; }
        public int StockQuantity { get; set; }

        public bool IsFeatured { get; set; } = false;

        public Guid CreatedBy { get; set; }     // FK -> User (default: super admin)

        // Navigation Properties
        public Category Category { get; set; } = null!;
        public ApplicationUser CreatedByUser { get; set; } = null!;
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<UserFavouriteProduct> FavouritedBy { get; set; } = new List<UserFavouriteProduct>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }

}
