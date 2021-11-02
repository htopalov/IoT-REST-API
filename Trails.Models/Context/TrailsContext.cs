﻿using Microsoft.EntityFrameworkCore;
using Utilities;

namespace Trails.Models.Context
{
    public class TrailsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.CONNECTION_STRING);
            }
        }


        public virtual DbSet<Device> Devices { get; set; }

        public virtual DbSet<PositionData> PositionData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PositionData>()
                .HasOne(x => x.Device)
                .WithMany(x => x.PositionData)
                .HasForeignKey(x => x.DeviceId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
