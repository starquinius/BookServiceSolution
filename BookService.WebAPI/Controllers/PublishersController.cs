using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        PublisherRepository _publisherRepository;

        public PublishersController(PublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        //api/Publishers
        [HttpGet] //Can only be called with an get request. Ok is needed and gives status of request and objedct
        public IActionResult GetPublishers()
        {
            return Ok(_publisherRepository.List());
        }

        //api/Publishers/{id}
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPublisher(int Id)
        {
            return Ok(_publisherRepository.GetById(Id));
        }


    }
}