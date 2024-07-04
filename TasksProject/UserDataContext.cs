using Microsoft.EntityFrameworkCore;

namespace TasksProject
{
    public class UserDataContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseSqlServer("Data Source=localhost;Database=UserDemoDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=False");


        }  
        public DbSet<User> Users { get; set; }
        public DbSet<AddUsers> AddUsers { get; set; }


        //   protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<person>()
        //.ToTable("persons");

        //     modelBuilder.Entity<PersonWithPrice>()
        //         .ToTable("persons")
        //         .HasBaseType<person>();
        // } 

    }

}
