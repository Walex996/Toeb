namespace Toeb.DataAccess.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ToebEntities : DbContext
    {
        public ToebEntities()
            : base("name=ToebEntities")
        {
        }

        public virtual DbSet<C__MigrationLog> C__MigrationLog { get; set; }
        public virtual DbSet<AccountDetail> AccountDetails { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<Estate> Estates { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<NextOfKin> NextOfKins { get; set; }
        public virtual DbSet<ServiceCharge> ServiceCharges { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Structure> Structures { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<C__MigrationLog>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<C__MigrationLog>()
                .Property(e => e.package_version)
                .IsUnicode(false);

            modelBuilder.Entity<C__MigrationLog>()
                .Property(e => e.release_version)
                .IsUnicode(false);

            modelBuilder.Entity<AccountDetail>()
                .HasMany(e => e.ServiceCharges)
                .WithRequired(e => e.AccountDetail)
                .HasForeignKey(e => e.AccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Building>()
                .HasMany(e => e.Complaints)
                .WithRequired(e => e.Building)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Building>()
                .HasMany(e => e.ServiceCharges)
                .WithRequired(e => e.Building)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Building>()
                .HasMany(e => e.Tenants)
                .WithRequired(e => e.Building)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Estate>()
                .HasMany(e => e.Buildings)
                .WithRequired(e => e.Estate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estate>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Estate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estate>()
                .HasMany(e => e.Tenants)
                .WithRequired(e => e.Estate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.InviteType)
                .IsUnicode(false);

            modelBuilder.Entity<NextOfKin>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.NextOfKin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Estates)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.State)
                .HasForeignKey(e => e.StateOfOriginId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Structure>()
                .HasMany(e => e.Buildings)
                .WithRequired(e => e.Structure)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subscription>()
                .HasMany(e => e.Estates)
                .WithRequired(e => e.Subscription)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.AccountDetails)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.EstateOwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Buildings)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Complaints)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.TenantId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Estates)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCharges)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.EstateOwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Tenant)
                .WithRequired(e => e.User);
        }
    }
}
