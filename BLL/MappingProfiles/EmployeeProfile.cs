﻿namespace BLL.MappingProfiles;

internal class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeRequest, Employee>();
        CreateMap<EmployeeUpdateRequest, Employee>();

        CreateMap<Employee, EmployeeDetailedResponse>();
        CreateMap<Employee, EmployeeResponse>().ForMember(d => d.Department, o => o.MapFrom(
            s => s.Department.Name));

        CreateMap<EmployeeUpdateRequest, EmployeeRequest>();
    }
}
