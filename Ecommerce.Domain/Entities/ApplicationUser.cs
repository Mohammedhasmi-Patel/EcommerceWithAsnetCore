using Ecommerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ProfileUrl { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; } = nameof(UserRole.Customer); 

        public string? RefreshToken { get; set; }
        public DateTime? TokenExpiredTime { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTime? DeletedAt { get; set; }

        public ICollection<UserAddress> Addresses { get; set; } = new List<UserAddress>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<UserFavouriteProduct> FavouriteProducts { get; set; } = new List<UserFavouriteProduct>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
