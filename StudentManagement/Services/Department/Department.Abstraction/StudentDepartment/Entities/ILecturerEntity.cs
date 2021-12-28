using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentDepartment.Abstraction.StudentDepartment.Entities
{
   public interface ILecturerEntity : IAggregateRoot
    {
     
         string Name { get; set; }
         Guid DepartmentId { get; set; }
         Guid CourseId { get; set; }
    }
}
