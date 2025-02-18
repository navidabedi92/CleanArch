using CleanArch.Application.Contracts.Persistence;
using MediatR;

namespace CleanArch.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    public readonly ILeaveTypeRepository _leaveTypeRepository;

    public DeleteCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // retrieve to domain entity object
        var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

        //verify that record exist

        // remove from db
        await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
   
        return Unit.Value;
    }
}
