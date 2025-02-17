using AutoMapper;
using CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CleanArch.Doamin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDTO, LeaveType>().ReverseMap();
    }
}
