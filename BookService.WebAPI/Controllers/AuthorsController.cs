using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        AuthorRepository _authorRepository;

        public AuthorsController(AuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        //api/Authors
        [HttpGet] //Can only be called with an get request. Ok is needed and gives status of request and objedct
        public IActionResult GetAuthors()
        {
            return Ok(_authorRepository.List());
        }

        //api/Authors/Basic
        [HttpGet]
        [Route("Basic")] //Als woordje basic bij de route staat, dan deze httpget uitvoeren
        public IActionResult GetAuthorBasic()
        {
            return Ok(_authorRepository.GetAuthorBasic());
        }

        //api/Authors/{id}
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAuthor(int Id)
        {
            return Ok(_authorRepository.GetById(Id));
        }

    }
}
