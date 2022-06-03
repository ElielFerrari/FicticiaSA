using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
