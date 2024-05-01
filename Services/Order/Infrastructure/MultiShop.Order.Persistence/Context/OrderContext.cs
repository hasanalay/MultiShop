using System;
using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context
{
	public class OrderContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;User Id=SA;Password=Passwd1234;Initial Catalog=MultiShopOrderDb;Integrated Security=true;Trusted_Connection=False;");
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> MyProperty { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}

