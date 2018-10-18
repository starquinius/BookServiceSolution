using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class PublisherRepository
    {
        //Context
        private BookServiceContext bookServiceContext;

        public PublisherRepository(BookServiceContext context)
        {
            bookServiceContext = context;
        }

        //List all publishers
        public List<Publisher> List()
        {
            return bookServiceContext.Publishers.ToList();
        }

        //List publisher by Id
        public Publisher GetById(int publisherId)
        {
            return bookServiceContext.Publishers.Where(pu => pu.Id == publisherId).FirstOrDefault();
        }
    }
}
