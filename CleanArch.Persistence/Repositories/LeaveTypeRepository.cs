
using CleanArch.Application.Contracts.Persistence;
using CleanArch.Domain;
using CleanArch.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(CADatabaseContext context) : base(context)
    {
    }

    public async Task<bool> IsLeaveTypeUnique(string name)
    {
        return await this._context.LeaveTypes.AnyAsync(q => q.Name == name) == false;
    }
}
