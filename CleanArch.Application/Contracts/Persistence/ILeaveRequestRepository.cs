
using CleanArch.Domain;

namespace CleanArch.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetails(int id);

    Task<List<LeaveRequest>> GetLeaveRequestWithDetails();

    Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId);
}

