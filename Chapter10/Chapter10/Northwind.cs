using Microsoft.EntityFrameworkCore;


namespace WorkingWithEFCore.Manual
{
    public class Northwind:DbContext
    {
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = $"Data Source=.; Initial Catalog=Northwind; Integrated Security=true; MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

        }
    }
}
