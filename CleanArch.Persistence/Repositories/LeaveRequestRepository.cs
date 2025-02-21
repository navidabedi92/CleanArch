
using CleanArch.Application.Contracts.Persistence;
using CleanArch.Domain;
using CleanArch.Persistence.DatabaseContext;

namespace CleanArch.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(CADatabaseContext context) : base(context)
    {
    }
}
