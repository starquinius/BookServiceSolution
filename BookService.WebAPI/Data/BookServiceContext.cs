using BookService.WebAPI.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Data
{
    public class BookServiceContext : DbContext
    {
        //Constructor   
        public BookServiceContext(DbContextOptions<BookServiceContext> options) : base(options)
        {
            
        }

        //Override (shortcut: tik override, dan spatie, kies dan juiste methode uit de lijst)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>()
                .HasData(
                new Publisher(1, "IT-Publishers", "UK"),
                new Publisher(2, "FoodBooks", "Sweden")
                );

            modelBuilder.Entity<Author>()
                .HasData(
                new Author(1,"James", "Sharp", new DateTime(1980, 5, 20)),
                new Author(2, "Sophie", "Netty", new DateTime(1992,3,4)),
                new Author(3, "Elisa", "Yammy", new DateTime(1996,8,12))
                );



            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


    }
}
