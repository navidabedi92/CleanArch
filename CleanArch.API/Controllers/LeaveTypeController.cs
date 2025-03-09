using CleanArch.Application.Features.LeaveType.Commands.CreateLeaveType;
using CleanArch.Application.Features.LeaveType.Commands.DeleteLeaveType;
using CleanArch.Application.Features.LeaveType.Commands.UpdateLeaveType;
using CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CleanArch.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using CleanArch.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        public IMediator _mediator { get; }

        public LeaveTypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<List<LeaveTypeDTO>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());

            return leaveTypes;
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDetailsDTO>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
            return Ok(leaveType);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateLeaveTypeCommand leaveType)
        {
            var response = await _mediator.Send(leaveType);
            return CreatedAtAction(nameof(Get) , new { id = response });
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateLeaveTypeCommand leaveType)
        {
           await _mediator.Send(leaveType);
            return NoContent();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            DeleteLeaveTypeCommand command = new DeleteLeaveTypeCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
