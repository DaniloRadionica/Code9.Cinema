using Code9.API.Models;
using Code9.Domain.Commands;
using Code9.Domain.Models;
using Code9.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Code9.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : Controller
    {
        private readonly IMediator _mediator;

        public CinemaController(IMediator mediator)
        {
           _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cinema>>> GetAllCinema()
        {
            var query = new GetAllCinemaQuery();
            var cinema = await _mediator.Send(query);
            return Ok(cinema);
        }

        [HttpPost]
        public async Task<ActionResult<Cinema>> addCinema(AddCinemaRequest request) 
        {
            var cinema = new AddCinemaCommand
            {
                Name = request.Name,
                City = request.City,
                Street = request.Street,
                NumberOfAuditoriums = request.NumberOfAuditoriums
            };
            var newCinema = await _mediator.Send(cinema);
            return Ok(newCinema);
        }
    }
}
