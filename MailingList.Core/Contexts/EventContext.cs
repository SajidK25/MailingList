using System;
using MailingList.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailingList.Core.Contexts
{
    public class EventContext : DbContext, IEventContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public EventContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerEvent>()
                .HasKey(ce => new { ce.CustomerId, ce.EventId });
            builder.Entity<CustomerEvent>()
                .HasOne(ce => ce.Customer)
                .WithMany(c => c.CustomerEvents)
                .HasForeignKey(ce => ce.CustomerId);

            builder.Entity<CustomerEvent>()
                .HasOne(ce => ce.Event)
                .WithMany(c => c.CustomerEvents)
                .HasForeignKey(ce => ce.EventId);
            base.OnModelCreating(builder);
        }

        public DbSet<Event> events { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerEvent> customerEvents { get; set; }
    }
}
