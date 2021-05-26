using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCore.Repository
{
    public class CoursesContext : DbContext
    {
        public CoursesContext()
        {

        }
        public CoursesContext(DbContextOptions<CoursesContext> optionsBuilder) : base(optionsBuilder)
        {
        
        }
        
        public DbSet<Courses> courses { get; set; }
        public DbSet<Category> category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=5Q#j$8#-#jzBrqNe;Persist Security Info=True;User ID=sa;Initial Catalog=CourseApp;Data Source=DESKTOP-8FVVO8D");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Courses>()
                .Property(s => s.CategoryId)
                .HasConversion<int>();

            modelBuilder
                .Entity<Category>()
                .Property(e => e.Id)
                .HasConversion<int>();

            modelBuilder
                .Entity<Category>().HasData(
                    Enum.GetValues(typeof(CategoryId))
                    .Cast<CategoryId>()
                    .Select(e => new Category()
                    {
                        Id = e,
                        Description = e.ToString()
                    }));
        }
    }
}
