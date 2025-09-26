using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities;

// POCO CLASSES
public class BaseEntity
{
    public int Id { get; set; } // => PK
    public bool isDeleted { get; set; } // soft deletion
    public int createdBy { get; set; } // userID
    public DateTime CreatedOn { get; set; } //
    public int LastModifiedBy { get; set; } //user iD
    public DateTime LastModifiedOn { get; set; }
}
