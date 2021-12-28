
using StudentDepartment.Abstraction.StudentDepartment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDepartment.Abstraction.StudentDepartment.Repositories
{
   public interface ILecturerRepository:IRepository<ILecturerEntity,Guid>
    {

      
    }
}
