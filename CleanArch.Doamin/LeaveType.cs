using CleanArch.Doamin.Common;

namespace CleanArch.Doamin;

public class LeaveType: BaseEntity
{
    public string Name { get; set; }=string.Empty;

    public int DefaultDays { get; set; }
}
