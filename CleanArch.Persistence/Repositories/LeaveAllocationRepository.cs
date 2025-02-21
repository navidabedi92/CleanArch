
using CleanArch.Application.Contracts.Persistence;
using CleanArch.Domain;
using CleanArch.Persistence.DatabaseContext;

namespace CleanArch.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(CADatabaseContext context) : base(context)
    {
    }
}
