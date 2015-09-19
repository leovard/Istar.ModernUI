using System.Data.Entity;

namespace IstarWindows.Models
{
    public class IstarContext : DbContext
    {
        public IstarContext()
            : base("name=Default")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<IstarContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<IstarContext>());
        }

        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Period> Periods { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Renter> Renters { get; set; }
        public virtual DbSet<Counter> Counters { get; set; }
        public virtual DbSet<Paytype> Paytypes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Building)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Building>()
                .HasMany(e => e.Offices)
                .WithRequired(e => e.Building)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Building>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.Building)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Inn)
                .HasPrecision(12, 0);

            modelBuilder.Entity<Company>()
                .Property(e => e.Kpp)
                .HasPrecision(9, 0);

            modelBuilder.Entity<Company>()
                .Property(e => e.Curaccount)
                .HasPrecision(20, 0);

            modelBuilder.Entity<Company>()
                .Property(e => e.Coraccount)
                .HasPrecision(20, 0);

            modelBuilder.Entity<Company>()
                .Property(e => e.Bik)
                .HasPrecision(9, 0);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Renters)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Office>()
                .Property(e => e.Area)
                .HasPrecision(4, 1);

            modelBuilder.Entity<Office>()
                .HasMany(e => e.Renters)
                .WithRequired(e => e.Office)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paytype>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Paytype)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Renter>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Renter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.Newdata)
                .HasPrecision(18, 1);

            modelBuilder.Entity<Report>()
                .Property(e => e.Prevdata)
                .HasPrecision(18, 1);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.Counters)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);
        }
    }
}
