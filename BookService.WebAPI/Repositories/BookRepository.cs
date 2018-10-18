using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class BookRepository
    {
        //Context
        private BookServiceContext bookServiceContext;

        public BookRepository(BookServiceContext context)
        {
            bookServiceContext = context;
        }

        //List all books
        public List<Book> List()
        {
            return bookServiceContext.Books.Include(b => b.Author).Include(b => b.Publisher).ToList();
        }

        //List basics for books
        public List<BookBasic> ListBasic()
        {
            return bookServiceContext.Books.Select(bk=> new BookBasic { Id = bk.Id, Title = bk.Title }).ToList();
        }

        //List book by Id
        public Book GetById(int bookId)
        {
            return bookServiceContext.Books.Where(bk => bk.Id == bookId).FirstOrDefault();
        }

        //Get image by book
        public string GetImage(int bookId)
        {

            return bookServiceContext.Books.Where(bk => bk.Id == bookId).Select(bk => bk.FileName).FirstOrDefault();
        }


    }
}
