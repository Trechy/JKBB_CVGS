namespace JKBB_CVGS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CVGS_Context : DbContext
    {
        public CVGS_Context()
            : base("name=CVGS_Context")
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.EventName)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Developer)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Publisher)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.BasePrice)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.Wishlists)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Role)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Province)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Wishlists)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Events)
                .WithMany(e => e.Users)
                .Map(m => m.ToTable("Register").MapLeftKey("Email").MapRightKey("EventID"));

            modelBuilder.Entity<Wishlist>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
