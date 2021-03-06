﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BookRepository _bookRepository;

        public BooksController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //api/Books
        [HttpGet] //Can only be called with an get request. Ok is needed and gives status of request and objedct
        public IActionResult GetBooks()
        {
            return Ok(_bookRepository.List());
        }

        //api/Books/Basic
        [HttpGet]
        [Route("Basic")] //Als woordje basic bij de route staat, dan deze httpget uitvoeren
        public IActionResult GetBookBasic()
        {
            return Ok(_bookRepository.ListBasic());
        }

        //api/books/{id}
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBook(int Id)
        {
            return Ok(_bookRepository.GetById(Id));
        }

        //api/books/ImageByName/{id}
        [Route("ImageByName/{fileNaam}")]
        public IActionResult GetImage(string fileNaam)
        {
            var pathName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileNaam);
            return PhysicalFile(pathName, "image/jpeg");
        }

        //api/books/ImageByName/{id}
        [Route("ImageById/{Id}")]
        public IActionResult GetImage(int Id)
        {           
            var pathName =Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images" , _bookRepository.GetImage(Id));
            return PhysicalFile(pathName, "image/jpeg");
        }
    }
}