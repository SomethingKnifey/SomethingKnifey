using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnifeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace KnifeStore.Data
{
    public class KnifeDbContext : DbContext
    {
        public KnifeDbContext(DbContextOptions<KnifeDbContext> options) : base(options)
        {
        }

        public DbSet<Knife> Knives { get; set; }
    }
}
