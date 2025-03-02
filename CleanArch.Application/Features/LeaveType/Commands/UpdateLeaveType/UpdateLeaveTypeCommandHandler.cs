using AutoMapper;
using CleanArch.Application.Contracts.Logging;
using CleanArch.Application.Contracts.Persistence;
using CleanArch.Application.Exceptions;
using MediatR;

namespace CleanArch.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    public readonly IMapper _mapper;
    public readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<UpdateLeaveTypeCommand> _logger;

    public UpdateLeaveTypeCommandHandler(IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository,
        IAppLogger<UpdateLeaveTypeCommand> logger)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request,
        CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}"
                , nameof(LeaveType), request.Id);
            throw new BadRequestException("Invalid Leave type", validationResult);
        }
        // convert to domain entity object
        var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);
        // add to db
        await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
        // return record id
        return Unit.Value;
    }
}
