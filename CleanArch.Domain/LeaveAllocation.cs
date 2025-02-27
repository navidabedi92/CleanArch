using CleanArch.Domain.Common;

namespace CleanArch.Domain;

public class LeaveAllocation : BaseEntity
{
    public int NummberOfDays { get; set; }

    public LeaveType? LeaveType { get; set; }

    public int LeaveTypeId { get; set; }

    public int Period { get; set; }

    public string EmployeeId { get; set; } = string.Empty;

}
