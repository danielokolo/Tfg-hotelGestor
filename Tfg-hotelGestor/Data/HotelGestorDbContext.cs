using Microsoft.EntityFrameworkCore;
using Tfg_hotelGestor.Entities;


namespace Tfg_hotelGestor.Data
{
    public class HotelGestorDbContext : DbContext 
    {
        public HotelGestorDbContext(DbContextOptions options) : base(options)
        { }
        public HotelGestorDbContext() { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerContact> CustomerContact { get; set; }
        public DbSet<CustomerBasicInfo> CustomerBasicInfo { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoicesDetails { get; set; }
        public DbSet<Vacancy> Vacancy { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomType> RoomType { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }

    }
}
