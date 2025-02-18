

using AutoMapper;
using CleanArch.Application.Contracts.Persistence;
using MediatR;

namespace CleanArch.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    public readonly IMapper _mapper;
    public readonly ILeaveTypeRepository _leaveTypeRepository;

    public DeleteCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data

        // convert to domain entity object
        var leaveTypeToDelete = _mapper.Map<Domain.LeaveType>(request);
        // add to db
        await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
        // return record id
        return Unit.Value;
    }
}
