﻿using ExemploCleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExemploCleanArchitecture.Infra.Data.Context;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(user => user.Email).HasMaxLength(255);
        modelBuilder.Entity<User>().Property(user => user.Name).HasMaxLength(255);
        modelBuilder.Entity<User>().Property(user => user.Password).HasMaxLength(255);
        modelBuilder.Entity<User>().Property(user => user.RegistryDate).HasColumnType("timestamp");
    }
}

