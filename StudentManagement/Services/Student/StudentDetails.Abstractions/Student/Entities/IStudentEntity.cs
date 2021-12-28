
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;


namespace StudentDetails.Abstraction.Student.Entities
{
  public  interface IStudentEntity : IAggregateRoot

    {
         
         string Name { get; set; }
         string Address { get; set; }
         string Gender { get; set; }
         Guid DepartmentId { get; set; }
         string Level { get; set; }
    }
    
}
