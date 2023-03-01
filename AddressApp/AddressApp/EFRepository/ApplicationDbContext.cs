using AddressApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressApp.EFRepository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Contact> ASPContactInformation { get; set; }
    }
}
