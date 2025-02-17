
using MediatR;

namespace CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDTO>>
{
    public Task<List<LeaveTypeDTO>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        //Query the database

        //convert data objects to DTO objects

        //return list of DTO object
        throw new NotImplementedException();
    }
}
