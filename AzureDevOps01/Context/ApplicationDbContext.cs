using AzureDevOps01.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureDevOps01.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Producto> Producto { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
    }
}
