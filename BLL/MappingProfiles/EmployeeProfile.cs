namespace BLL.MappingProfiles;

internal class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeRequest, Employee>();
        CreateMap<EmployeeUpdateRequest, Employee>();

        CreateMap<Employee, EmployeeDetailedResponse>();
        CreateMap<Employee, EmployeeResponse>();

        CreateMap<EmployeeUpdateRequest, EmployeeRequest>();
    }
}
