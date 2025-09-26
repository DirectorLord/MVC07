using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DataTransferObject.Department
{
    public class DepartmentDetailResponse
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
