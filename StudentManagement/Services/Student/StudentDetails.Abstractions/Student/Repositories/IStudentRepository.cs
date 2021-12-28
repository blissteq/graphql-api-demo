
using StudentDetails.Abstraction.Student.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;
using ZA365Solutions.Platform.Common.Enums;

namespace StudentDetails.Abstraction.Repositories
{
  public  interface IStudentRepository:IRepository<IStudentEntity,Guid>
    {
        
    }
}
