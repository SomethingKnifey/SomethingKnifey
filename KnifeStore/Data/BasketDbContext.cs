using KnifeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace KnifeStore.Data
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options)
        {
        }

        public DbSet<Basket> Baskets { get; set; }
    }
}
