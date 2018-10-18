using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Models
{
    public class Book
    {
        //Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        [Display(Name="#")]
        public int NumberOfPages { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public string FileName { get; set; }

        //Constructor
        public Book() { }

        //Constructor Overload
        public Book(int id, string title, string isbn, int numberOfPages, Author author, Publisher publisher, string fileName ="")
        {
            Id = id;
            Title = title;
            ISBN = isbn;
            NumberOfPages = numberOfPages;
            Author = author;
            Publisher = publisher;
            FileName = fileName;
        }
        
    }
}
