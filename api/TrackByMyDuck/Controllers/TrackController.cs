using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackByMyDuck.Application.Features.Tracks.Commands.AddTrack;
using TrackByMyDuck.Application.Features.Tracks.Commands.CheckTrack;
using TrackByMyDuck.Application.Features.Tracks.Queries.GetShowTrack;
using TrackByMyDuck.Application.Features.Tracks.Queries.GetTracks;

namespace TrackByMyDuck.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TrackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllTracks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<object>> GetAllTracks()
        {
            var result = await _mediator.Send(new GetTracksQuery());
            return Ok(result);
        }

        [HttpPost("add-track", Name = "AddTrack")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddTrack([FromBody]AddTrackCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("check-track", Name = "CheckTrack")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CheckTrack([FromBody]CheckTrackCommand request)
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