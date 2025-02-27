
using CleanArch.Application.Contracts.Persistence;
using CleanArch.Domain;
using CleanArch.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(CADatabaseContext context) : base(context)
    {

    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
    {
        var leaveReuests = await _context.LeaveRequests
          .Include(q => q.LeaveType)
          .ToListAsync();

        return leaveReuests;
    }
    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
    {
        var leaveReuests = await _context.LeaveRequests
             .Where(q => q.RequestingEmployeeId == userId)
             .Include(q => q.LeaveType)
             .ToListAsync();

        return leaveReuests;
    }
    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveReuest = await _context.LeaveRequests
            .Include(q => q.LeaveType).FirstOrDefaultAsync(q => q.Id == id);
        return leaveReuest;
    }
}

   
}
