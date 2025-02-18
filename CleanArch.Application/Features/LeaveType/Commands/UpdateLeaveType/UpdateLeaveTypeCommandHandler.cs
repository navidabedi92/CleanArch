using AutoMapper;
using CleanArch.Application.Contracts.Persistence;
using MediatR;

namespace CleanArch.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    public readonly IMapper _mapper;
    public readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository; 
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request,
        CancellationToken cancellationToken)
    {
        // Validate incoming data

        // convert to domain entity object
        var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);
        // add to db
        await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
        // return record id
        return Unit.Value;
    }
}
