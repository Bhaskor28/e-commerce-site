﻿using DbHandson.Models;
using Microsoft.EntityFrameworkCore;

namespace DbHandson.Data
{
    public class ProductDbContext : DbContext
    {

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> productinfo { get; set; }

    }
}
