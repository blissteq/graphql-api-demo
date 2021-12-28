using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Messaging;

namespace StudentDepartment.Abstraction.StudentDepartment.Models
{
  public  class Lecturer:  ICommandData, IEventData
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid CourseId { get; set; }
    }
}
