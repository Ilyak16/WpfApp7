using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApp7.Models;

namespace WpfApp7.Domain
{
    public class MyDataBaseContext : DbContext
    {
        private readonly string connectionString = null!;
        public DbSet<User> Users { get; set; }
        public MyDataBaseContext(string connString)
        {
            connectionString = connString;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<User>().HasData([
            new User(1, "Name1",123),
            new User(2, "Name2",5),
            new User(3, "Name3",-9999),
            new User(4, "Name4",-9999),
            ]);
        }
    }
}
