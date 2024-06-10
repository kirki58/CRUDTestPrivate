﻿using CRUDTest.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRUDTest.DataAccess.DBC;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions options ) :  base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
}
