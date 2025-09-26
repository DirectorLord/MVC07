using DAL.Entities;

namespace DAL.Reporsitories;

public class DeparmentRepository(CompanyDBContext dbConext) 
    : BaseRepository<Department>(dbConext) ,IRepository<Department>
{

}
