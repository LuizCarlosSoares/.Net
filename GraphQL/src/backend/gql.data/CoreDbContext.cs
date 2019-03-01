   using gql.core.model;
   using Microsoft.EntityFrameworkCore;
   namespace gql.data {
       public sealed class CoreDbContext : DbContext {

           public CoreDbContext (DbContextOptions options) : base (options) {
               // these are mutually exclusive, migrations cannot be used with EnsureCreated()
              //  Database.EnsureCreated();
               //Database.Migrate ();
           }

           public DbSet<Game> Games { get; set; }
           public DbSet<Company> Companies { get; set; }

           protected override void OnModelCreating (ModelBuilder modelBuilder) {

               base.OnModelCreating (modelBuilder);

               modelBuilder.Entity<Game> ()
                   .HasKey (c => c.Id);

               modelBuilder.Entity<Company> ()
                   .HasKey (c => c.Id);
           }

       }
   }