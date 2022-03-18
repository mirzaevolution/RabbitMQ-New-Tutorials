using MassTransit.Producer.Commands;
using MassTransit.Producer.Models.Messages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassTransit.Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(PostMessageResponse), 200)]
        public async Task<IActionResult> Post([FromBody] PostMessageRequest request)
        {
            if (ModelState.IsValid)
            {
                string result = await _mediator.Send(new PublishMessageCommand
                {
                    Message = request.Message,
                    CreatedBy = request.CreatedBy
                });
                return Ok(new PostMessageResponse
                {
                    Result = result
                });
            }
            return BadRequest(ModelState);
        }
    }
}
