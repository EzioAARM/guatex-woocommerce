﻿using GuatexWoocommerce.Database;
using Microsoft.EntityFrameworkCore;

namespace GuatexWoocommerce
{
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Tabla de direcciones
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                (string host, string user, string password, string database) = GuatexSendings.GetMysqlSettings();
                _ = optionsBuilder
                    .UseMySql($"",
                        new MySqlServerVersion(new Version(8, 0, 31)),
                        builder =>
                        {
                            _ = builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                        });
            }
        }

        public override int SaveChanges()
        {
            DateTime now = DateTime.UtcNow;
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is IEntityDate dateEntity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            dateEntity.CreatedAt = now;
                            dateEntity.UpdatedAt = now;
                            break;
                        case EntityState.Modified:
                            Entry(dateEntity).Property(x => x.CreatedAt).IsModified = false;
                            dateEntity.UpdatedAt = now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}