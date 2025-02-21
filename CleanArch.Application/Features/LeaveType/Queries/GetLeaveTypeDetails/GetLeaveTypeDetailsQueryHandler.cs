
using AutoMapper;
using CleanArch.Application.Contracts.Persistence;
using CleanArch.Application.Exceptions;
using CleanArch.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
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
        var leaveType = await this._leaveTypeRepository.GetByIdAsync(request.Id);

        //verify that record exists
        if (leaveType == null)
            throw new NotFoundException(nameof(LeaveType), request.Id);

        //convert data objects to DTO objects
        var data = this._mapper.Map<LeaveTypeDetailsDTO>(leaveType);
        //return list of DTO object
        return data;
    }
}
