

namespace Library_DEPI.Data
{
    public class AppDBContext : IdentityDbContext
    {
        //public AppDBContext(DbContextOptions options) : base(options)
        //{
        //}
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<Penalty> Penalties { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                 new IdentityRole()
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = "Super Admin",
                     NormalizedName = "super admin",
                     ConcurrencyStamp = Guid.NewGuid().ToString()
                 },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }, new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "user",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
                );
        }
        //public DbSet<Library_DEPI.ViewModel.CheckoutViewModel> CheckoutViewModel { get; set; } = default!;

    }

}
