namespace Coursework.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AlpinistBases> AlpinistBases { get; set; }
        public virtual DbSet<Alpinists> Alpinists { get; set; }
        public virtual DbSet<AlpinistsList> AlpinistsList { get; set; }
        public virtual DbSet<FoodOrders> FoodOrders { get; set; }
        public virtual DbSet<FoodTypes> FoodTypes { get; set; }
        public virtual DbSet<HouseOrders> HouseOrders { get; set; }
        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<HouseTypes> HouseTypes { get; set; }
        public virtual DbSet<Routes> Routes { get; set; }
        public virtual DbSet<Walks> Walks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlpinistBases>()
                .HasMany(e => e.Houses)
                .WithRequired(e => e.AlpinistBases)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AlpinistBases>()
                .HasMany(e => e.AlpinistsList)
                .WithRequired(e => e.AlpinistBases)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AlpinistBases>()
                .HasMany(e => e.Routes)
                .WithRequired(e => e.AlpinistBases)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Alpinists>()
                .HasMany(e => e.AlpinistsList)
                .WithRequired(e => e.Alpinists)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Alpinists>()
                .HasMany(e => e.FoodOrders)
                .WithRequired(e => e.Alpinists)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Alpinists>()
                .HasMany(e => e.HouseOrders)
                .WithRequired(e => e.Alpinists)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Alpinists>()
                .HasMany(e => e.Walks)
                .WithRequired(e => e.Alpinists)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FoodTypes>()
                .HasMany(e => e.FoodOrders)
                .WithRequired(e => e.FoodTypes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Houses>()
                .HasMany(e => e.HouseOrders)
                .WithRequired(e => e.Houses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HouseTypes>()
                .HasMany(e => e.Houses)
                .WithRequired(e => e.HouseTypes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Routes>()
                .HasMany(e => e.Walks)
                .WithRequired(e => e.Routes)
                .WillCascadeOnDelete(false);
        }
    }
}
