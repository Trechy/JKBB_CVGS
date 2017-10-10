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

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Member>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Province)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Members)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
