using DemoWIUTGallery.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoWIUTGallery.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Photo> Photoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure shadow properties for all entities
            var entities = modelBuilder.Model.GetEntityTypes();

            foreach(var entity in entities)
            {
                entity.AddProperty("CreatedDate", typeof(DateTime));
                entity.AddProperty("UpdatedDate", typeof(DateTime));
            }

            //seed data
            modelBuilder.Entity<Folder>().HasData(
                new { Id = 1, Name = "Books", UpdatedDate = DateTime.Now, CreatedDate = DateTime.Now },
                new { Id = 2, Name = "Mountains", UpdatedDate = DateTime.Now, CreatedDate = DateTime.Now },
                new { Id = 3, Name = "Lakes", UpdatedDate = DateTime.Now, CreatedDate = DateTime.Now }
                );

        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(s => s.State == EntityState.Added || s.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                entry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                if (entry.State == EntityState.Added)
                    entry.Property("CreatedDate").CurrentValue = DateTime.Now;
            }
            return base.SaveChanges();
        }
    }
}
