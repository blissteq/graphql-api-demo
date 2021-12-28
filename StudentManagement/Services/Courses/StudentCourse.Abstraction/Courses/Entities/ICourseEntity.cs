using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentCourse.Abstraction.Courses.Entities
{
   public interface ICourseEntity : IAggregateRoot
    {
         
         string Level { get; set; }
         string Name { get; set; }
         Guid DepartmentId { get; set; }
        Guid LecturerId { get; set; }
    }
}
