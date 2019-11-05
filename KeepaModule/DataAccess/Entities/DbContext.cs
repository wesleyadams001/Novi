namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KeepaContext : DbContext
    {
        
        public KeepaContext() : base(nameOrConnectionString: Properties.Settings.Default.CurrentConnString)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<KeepaContext>());
        }

        public virtual DbSet<best_sellers> best_sellers { get; set; }

        public virtual DbSet<category> categories { get; set; }

        public virtual DbSet<category_tree> category_tree { get; set; }

        public virtual DbSet<fba_fees> fba_fees { get; set; }

        public virtual DbSet<feature> features { get; set; }

        public virtual DbSet<language> languages { get; set; }

        public virtual DbSet<most_rated_sellers> most_rated_sellers { get; set; }

        public virtual DbSet<price_history> price_history { get; set; }

        public virtual DbSet<product> products { get; set; }

        public virtual DbSet<seller> sellers { get; set; }

        public virtual DbSet<sellers_listed_items> sellers_listed_items { get; set; }

        public virtual DbSet<variation> variations { get; set; }

        public virtual DbSet<ean> eans { get; set; }

        public virtual DbSet<freq_bought_together> freq_bought_together { get; set; }

        public virtual DbSet<statistic> statistics { get; set; }

        public virtual DbSet<upc> upcs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Keepa");

            modelBuilder.Entity<category_tree>()
                .Property(e => e.amzn_cat_id)
                .HasPrecision(19, 4);

            modelBuilder.Entity<price_history>()
                .Property(e => e.ob_date)
                .HasPrecision(19, 4);

            modelBuilder.Entity<price_history>()
                .Property(e => e.ob_price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<price_history>()
                .Property(e => e.ob_shipping)
                .HasPrecision(19, 4);

            modelBuilder.Entity<price_history>()
                .Property(e => e.time_stamp)
                .HasPrecision(19, 4);

            modelBuilder.Entity<product>()
                .Property(e => e.root_category)
                .HasPrecision(19, 4);
        }

        
    }
}
