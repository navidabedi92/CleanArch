
using AutoMapper;
using CleanArch.Application.Contracts.Logging;
using CleanArch.Application.Contracts.Persistence;
using MediatR;

namespace CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDTO>>
{
    public readonly IMapper _mapper;
    public readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

    public GetLeaveTypesQueryHandler(IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository,
        IAppLogger<GetLeaveTypesQueryHandler> logger)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
    }


    public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    { 
        //Query the database
        var leaveTypes = await _leaveTypeRepository.GetAsync();
        //convert data objects to DTO objects
        var data=_mapper.Map<List<LeaveTypeDTO>>(leaveTypes);
        //return list of DTO object
        _logger.LogInformation(" Leave types were retrieved successfully");
        return data;
    }
}
