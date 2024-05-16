using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Context
{
	public class DapperContext : DbContext
	{
		private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(DbContextOptions<DapperContext> options) : base (options)
        {
            
        }
        public DapperContext(IConfiguration configuration, bool isDapper)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost,1460;User Id=SA;Password=123456Aa*;Initial Catalog=MultiShopDiscountDb;Integrated Security=true;Trusted_Connection=False");
        //}

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}

