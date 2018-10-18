using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class AuthorRepository
    {
        //Context
        private BookServiceContext bookServiceContext;

        public AuthorRepository(BookServiceContext context)
        {
            bookServiceContext = context;
        }

        //List all authors
        public List<Author> List()
        {
            return bookServiceContext.Authors.ToList();
        }

        //List basics for authors
        public List<AuthorBasic> GetAuthorBasic()
        {
            return bookServiceContext.Authors.Select(au => new AuthorBasic { Id = au.Id, Name = au.LastName  + " " + au.FirstName  }).ToList();
        }

        //List author by ID
        public Author GetById(int authorId)
        {
            return bookServiceContext.Authors.Where(au => au.Id == authorId).FirstOrDefault();
        }

    }
}
