using Microsoft.EntityFrameworkCore;
using SupplierDiligenceApi.Models;

namespace SupplierDiligenceApi.Data
{
    public class SupplierContext : DbContext
    {
        public SupplierContext(DbContextOptions<SupplierContext> options) : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}

