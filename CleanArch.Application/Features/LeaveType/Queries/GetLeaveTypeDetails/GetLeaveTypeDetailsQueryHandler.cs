
using AutoMapper;
using CleanArch.Application.Contracts.Persistence;
using CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CleanArch.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using CleanArch.Doamin;
using MediatR;
namespace CleanArch.Application.Features.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDTO>
{
    public readonly IMapper _mapper;
    public readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }


    public async Task<LeaveTypeDetailsDTO> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    { 
        //Query the database
        var leaveTypes = await this._leaveTypeRepository.GetByIdAsync(request.Id);
        //convert data objects to DTO objects
        var data = this._mapper.Map<LeaveTypeDetailsDTO>(leaveTypes);
        //return list of DTO object
        return data;
    }
}
