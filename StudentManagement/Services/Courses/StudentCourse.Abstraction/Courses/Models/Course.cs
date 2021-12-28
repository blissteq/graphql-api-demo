using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Messaging;

namespace StudentCourse.Abstraction.Courses.Models
{
  public  class Course: BaseQueryModel, ICommandData, IEventData
    {
     
        public string Level { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid LecturerId { get; set; }
    }
}
