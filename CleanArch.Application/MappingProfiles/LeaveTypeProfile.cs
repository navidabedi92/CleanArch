using AutoMapper;
using CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CleanArch.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using CleanArch.Domain;
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
        CreateMap<LeaveType, LeaveTypeDetailsDTO>();
    }
}
