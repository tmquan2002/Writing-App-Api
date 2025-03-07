﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WritingApp.Domain.Entities;
namespace WritingApp.Infrastructure.Persistence;

internal class WritingsDbContext(DbContextOptions<WritingsDbContext> options)
    : IdentityDbContext<User>(options)
{
    internal DbSet<Writing> Writings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(r => r.Writings)
            .WithOne(r => r.Author)
            .HasForeignKey(d => d.UserId);

        modelBuilder.Entity<Writing>(entity =>
        {
            entity.Property(e => e.Completed)
                .HasColumnType("CHAR(1)")
                .HasDefaultValue(false)
                .HasConversion(
                    v => v ? "Y" : "N",
                    v => v == "Y"
                );
        });

        modelBuilder.Entity<User>(entity =>
        {

            entity.Property(e => e.EmailConfirmed)
                .HasColumnType("CHAR(1)")
                .HasDefaultValue(false)
                .HasConversion(
                    v => v ? "Y" : "N",
                    v => v == "Y"
                );

            entity.Property(e => e.PhoneNumberConfirmed)
                .HasColumnType("CHAR(1)")
                .HasDefaultValue(false)
                .HasConversion(
                    v => v ? "Y" : "N",
                    v => v == "Y"
                );

            entity.Property(e => e.LockoutEnabled)
                .HasColumnType("CHAR(1)")
                .HasDefaultValue(false)
                .HasConversion(
                    v => v ? "Y" : "N",
                    v => v == "Y"
                );

            entity.Property(e => e.TwoFactorEnabled)
                .HasColumnType("CHAR(1)")
                .HasDefaultValue(false)
                .HasConversion(
                    v => v ? "Y" : "N",
                    v => v == "Y"
                );
        });
    }
}
