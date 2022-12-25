using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrackByMyDuck.Application.Features.Tracks.Commands.AddTrack;
using TrackByMyDuck.Application.Features.Tracks.Queries.GetShowTrack;

namespace TrackByMyDuck.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TrackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddTrack")]
        public async Task<IActionResult> AddTrack([FromBody]AddTrackCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("get-show-track", Name = "GetShowTrack")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetShowTrack()
        {
            var result = await _mediator.Send(new GetShowTrackQuery());
            return Ok(result);
        }
    }
}