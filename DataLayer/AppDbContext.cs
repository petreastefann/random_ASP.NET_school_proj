﻿using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer {
	public class AppDbContext : DbContext {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=dawm_database;Username=postgres;Password=postgres;Pooling=true;")
					.LogTo(Console.WriteLine);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Class>().Property(e => e.Name).HasMaxLength(10);
		}

		public DbSet<Class> Classes {
			get; set;
		}
		public DbSet<Grade> Grades {
			get; set;
		}
		public DbSet<Student> Students {
			get; set;
		}
		public DbSet<User> Users {
			get; set;
		}
	}
}
