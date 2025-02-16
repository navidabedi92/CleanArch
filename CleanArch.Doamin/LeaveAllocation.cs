using CleanArch.Doamin.Common;

namespace CleanArch.Doamin;

public class LeaveAllocation: BaseEntity
{
    public int NummberOfDays { get; set; }

    public LeaveType? LeaveType { get; set; }

    public int LeaveTypeId { get; set; }

    public int Period { get; set; }

}
