using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1
{
    public partial class RecordContext : DbContext
    {
        public RecordContext()
            : base("name=RecordContext")
        {
        }

        public virtual DbSet<record> records { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<record>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<record>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<record>()
                .Property(e => e.stage)
                .IsUnicode(false);

            modelBuilder.Entity<record>()
                .Property(e => e.platform)
                .IsUnicode(false);

            modelBuilder.Entity<record>()
                .Property(e => e.platformURL)
                .IsUnicode(false);

            modelBuilder.Entity<record>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
